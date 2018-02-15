using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LCARS.Models;

namespace LCARS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ObjectivesController : Controller
    {
        private readonly GameContext _context;

        public ObjectivesController(GameContext context)
        {
            _context = context;
        }

        // GET: Admin/Objectives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Objectives.ToListAsync());
        }

        // GET: Admin/Objectives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Objectives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjectiveId,Title,Description")] Objective objective)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objective);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objective);
        }

        // GET: Admin/Objectives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objective = await _context.Objectives.SingleOrDefaultAsync(m => m.ObjectiveId == id);
            if (objective == null)
            {
                return NotFound();
            }
            return View(objective);
        }

        // POST: Admin/Objectives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObjectiveId,Title,Description")] Objective objective)
        {
            if (id != objective.ObjectiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objective);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectiveExists(objective.ObjectiveId))
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
            return View(objective);
        }

        // GET: Admin/Objectives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objective = await _context.Objectives
                .SingleOrDefaultAsync(m => m.ObjectiveId == id);
            if (objective == null)
            {
                return NotFound();
            }

            return View(objective);
        }

        // POST: Admin/Objectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objective = await _context.Objectives.SingleOrDefaultAsync(m => m.ObjectiveId == id);
            _context.Objectives.Remove(objective);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectiveExists(int id)
        {
            return _context.Objectives.Any(e => e.ObjectiveId == id);
        }
    }
}
