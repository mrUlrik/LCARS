using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LCARS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LCARS.Models;
using Attribute = LCARS.Models.Attribute;

namespace LCARS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttributesController : Controller
    {
        private readonly GameContext _context;

        public AttributesController(GameContext context)
        {
            _context = context;
        }

        // GET: Admin/Attributes
        public async Task<IActionResult> Index()
        {
            var gameContext = _context.Attributes.Include(a => a.Skill).Include(a => a.Location);
            return View(await gameContext.ToListAsync());
        }

        // GET: Admin/Attributes/Create
        public IActionResult Create()
        {
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "Name");
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name");
            return View();
        }

        // POST: Admin/Attributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttributeId,Name,Abbreviated,SkillId,LocationId,VariableType")] LCARS.Models.Attribute attribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "Name", attribute.SkillId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name", attribute.LocationId);
            return View(attribute);
        }

        // GET: Admin/Attributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes.SingleOrDefaultAsync(m => m.AttributeId == id);
            if (attribute == null)
            {
                return NotFound();
            }
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "Name", attribute.SkillId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name", attribute.LocationId);
            return View(attribute);
        }

        // POST: Admin/Attributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttributeId,Name,Abbreviated,SkillId,LocationId,VariableType")] LCARS.Models.Attribute attribute)
        {
            if (id != attribute.AttributeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeExists(attribute.AttributeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SkillId"] = new SelectList(_context.Skills, "SkillId", "Name", attribute.SkillId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name", attribute.LocationId);
            return View(attribute);
        }

        // GET: Admin/Attributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes
                .Include(a => a.Skill)
                .SingleOrDefaultAsync(m => m.AttributeId == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        // POST: Admin/Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attribute = await _context.Attributes.SingleOrDefaultAsync(m => m.AttributeId == id);
            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeExists(int id)
        {
            return _context.Attributes.Any(e => e.AttributeId == id);
        }
    }
}
