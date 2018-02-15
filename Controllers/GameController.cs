using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LCARS.Controllers
{
    [Produces("application/json")]
    [Route("api/game")]
    public class GameController : Controller
    {
        private readonly GameContext _db;

        public GameController(GameContext context)
        {
            _db = context;
        }

        [HttpPut]
        public bool UpdateValue([FromBody] Game input)
        {
            var game = _db.Games.FirstOrDefault(x => x.GameId == input.GameId);
            if (game == null) return false;

            if (input.Sector != null)
                game.Sector = input.Sector;
            if (input.Slipgate != null)
                game.Slipgate = input.Slipgate;
            if (input.Status != 0)
                game.Status = input.Status;

            _db.Games.Update(game);
            var result = _db.SaveChanges();

            return result > 0;
        }
    }
}