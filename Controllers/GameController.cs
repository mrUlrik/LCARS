using System.Collections.Generic;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LCARS.Data;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public List<Game> GetList()
        {
            return _db.Games.Include(x => x.Players).ThenInclude(x => x.Character).Where(x => x.Status != GameStatus.Ended).ToList();
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