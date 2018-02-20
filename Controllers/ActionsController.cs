using System.Collections.Generic;
using System.Linq;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("character/{characterId}/location/{locationId}")]
        public List<Attribute> GetActions(int characterId, int locationId)
        {
            var character = _db.Characters.FirstOrDefault(x => x.CharacterId == characterId);
            if (character == null) return new List<Attribute>();

            var actions =  _db.Attributes.Where(x => x.LocationId == null || x.LocationId == locationId).ToList();
            var result = character.CharacterSkills.Select(skill => actions.FirstOrDefault(x => x.SkillId == skill.SkillId)).ToList();
            return actions;
        }
    }
}