using System;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCARS.Controllers
{
    [Produces("application/json")]
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpPost("create")]
        public Game Create(GameView input)
        {
            using (var db = new GameContext())
            {
                var game = new Game()
                {
                    Created = DateTime.Now,
                    IsActive = input.IsActive,
                    Name = input.Name
                };

                db.Games.Add(game);
                db.SaveChanges();
                return game;
            }
        }
    }
}