using System.Collections.Generic;
using System.Linq;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var character = _db.Characters.Include(x => x.CharacterSkills)
                .SingleOrDefault(x => x.CharacterId == characterId);
            if (character == null) return new List<Attribute>();

            var attributes = _db.Attributes.Where(x => x.LocationId == null || x.LocationId == locationId);

            var result = new List<Attribute>();
            foreach (var characterSkill in character.CharacterSkills)
                result = attributes.Where(x => x.SkillId == characterSkill.SkillId || x.SkillId == null).OrderBy(x => x.Name).ToList();
            return result;
        }
    }
}