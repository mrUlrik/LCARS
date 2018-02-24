using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using LCARS.Data;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.IISUrlRewrite;
using Microsoft.EntityFrameworkCore;
using Attribute = LCARS.Models.Attribute;

namespace LCARS.Controllers
{
    [Produces("application/json")]
    [Route("api/actions")]
    public class ActionsController : Controller
    {
        private readonly GameContext _db;

        public ActionsController(GameContext context)
        {
            _db = context;
        }

        [HttpGet("character/{playerId}/location/{locationId}")]
        public List<Attribute> GetActions(int playerId, int locationId)
        {
            var character = _db.Players.Include(x => x.Character).ThenInclude(x => x.CharacterSkills).SingleOrDefault(x => x.PlayerId == playerId)?.Character;
            if (character == null) return new List<Attribute>();

            var attributes = _db.Attributes.Where(x => x.LocationId == null || x.LocationId == locationId);

            var result = new List<Attribute>();
            foreach (var characterSkill in character.CharacterSkills)
                result.AddRange(attributes.Where(x => x.SkillId == characterSkill.SkillId || x.SkillId == null).OrderBy(x => x.Name).ToList());
            return result;
        }

        [HttpGet("location/{id}")]
        public List<Attribute> GetStations(int id)
        {
            return _db.Attributes.Where(x => x.LocationId == id).ToList();
        }

        [HttpGet("{id}/{locationId?}")]
        public List<string> GetAction(VariableType id, int? locationId = null)
        {
            switch (id)
            {
                case VariableType.None:
                    return new List<string>();
                case VariableType.MultipleChoice:
                    return new List<string>{ "A", "B", "C", "D" };
                case VariableType.Drones:
                    return _db.Drones.Select(x => x.Name).ToList();
                case VariableType.Locations:
                    return _db.Locations.Select(x => x.Name).ToList();
                case VariableType.Crew:
                    return _db.Characters.Select(x => x.Name).ToList();
                case VariableType.Stations:
                    return _db.Attributes.Where(x => x.LocationId == locationId).Select(x => x.Name).ToList();
                default:
                    throw new ArgumentOutOfRangeException(nameof(id), id, null);
            }
        }

        [HttpPost("perform")]
        public bool PerformAction([FromBody] PlayerAction input)
        {
            _db.Teleports.Add(new Teleport {GameId = input.GameId, LocationId = input.LocationId, PlayerId = input.PlayerId, Round = input.Round, Time = DateTime.Now});
            _db.SaveChanges();
            input.Time = DateTime.Now;
            _db.PlayerActions.Add(input);
            return _db.SaveChanges() > 0;
        }
    }
}