using System;
using System.Collections.Generic;
using System.Linq;
using LCARS.Areas.Admin.Models;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LCARS.Controllers
{
    [Produces("application/json")]
    [Route("api/status")]
    public class StatusController : Controller
    {
        private readonly GameContext _db;

        public StatusController(GameContext context)
        {
            _db = context;
        }

        [HttpPut]
        public bool UpdateValue([FromBody] Status input)
        {
            var status = _db.Statuses.FirstOrDefault(x => x.StatusId == input.StatusId);
            if (status == null) return false;

            status.Time = DateTime.Now;
            if (input.TextValue1 != null)
                status.TextValue1 = input.TextValue1;
            if (input.TextValue2 != null)
                status.TextValue2 = input.TextValue2;

            _db.Statuses.Update(status);
            var result = _db.SaveChanges();

            return result > 0;
        }

        [HttpGet("character/{id}")]
        public Character GetCharacter(int id)
        {
            return _db.Characters.Include(x => x.CharacterObjectives).ThenInclude(x => x.Objective)
                .Include(x => x.CharacterSkills).ThenInclude(x => x.Skill).FirstOrDefault(x => x.CharacterId == id);
        }

        [HttpGet("locations/{id}")]
        public List<LocationView> GetLocations(int id)
        {
            var game = _db.Games.SingleOrDefault(x => x.GameId == id);
            var locationAttributes = _db.Locations.Include(x => x.Attributes).ToList();
            var teleports = _db.Teleports.Include(x => x.Player)
                .Where(x => x.GameId == game.GameId && x.Round == game.Round).ToList();
            var statuses = _db.Statuses.Where(x => x.GameId == game.GameId && x.Round == game.Round)
                .OrderByDescending(x => x.Time).GroupBy(x => new {x.AttributeId, x.LocationId})
                .Select(x => x.FirstOrDefault()).ToList();
            return locationAttributes.Select(x => new LocationView
            {
                LocationId = x.LocationId,
                Name = x.Name,
                Abbreviated = x.Abbreviated,
                Attributes = x.Attributes.Select(y => new AttributeView
                {
                    AttributeId = y.AttributeId,
                    Name = y.Name,
                    Abbreviated = y.Abbreviated,
                    Status = statuses.Where(z => z.AttributeId == y.AttributeId).Select(z =>
                        new StatusView
                        {
                            StatusId = z.StatusId,
                            TextValue1 = z.TextValue1,
                            TextValue2 = z.TextValue2,
                            Time = z.Time
                        }).SingleOrDefault()
                }).ToList(),
                Teleports = teleports.Where(z => z.LocationId == x.LocationId)
                    .Select(z => new TeleportView {PlayerName = z.Player.Name}).ToList()
            }).ToList();
        }
    }
}