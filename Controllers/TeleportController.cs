using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LCARS.Controllers
{
    [Produces("application/json")]
    [Route("api/teleport")]
    public class TeleportController : Controller
    {
        private readonly GameContext _db;

        public TeleportController(GameContext context)
        {
            _db = context;
        }

        [HttpPut]
        public bool InsertValue([FromBody] Teleport input)
        {
            _db.Teleports.Add(input);
            var result = _db.SaveChanges();

            return result > 0;
        }
    }
}