using System;
using System.Collections.Generic;
using System.Linq;
using LCARS.Areas.Admin.Models;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LCARS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly GameContext _db;

        public HomeController(GameContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var runningGames = _db.Games.Where(x => x.IsActive).Select(x =>
                new GameView {Created = x.Created, GameId = x.GameId, IsActive = x.IsActive, Name = x.Name}).ToList();
            ViewBag.RunningGames = runningGames.Any() ? runningGames : new List<GameView>();

            var pastGames = _db.Games.Where(x => !x.IsActive).Select(x =>
                new GameView { Created = x.Created, GameId = x.GameId, IsActive = x.IsActive, Name = x.Name }).ToList();
            ViewBag.PastGames = pastGames.Any() ? pastGames : new List<GameView>();

            return View();
        }

        public IActionResult View(GameView input)
        {
            var game = new Game
            {
                Created = DateTime.Now,
                IsActive = true,
                Name = input.Name
            };

            _db.Games.Add(game);
            _db.SaveChanges();

            var result = new GameView
            {
                Created = game.Created,
                GameId = game.GameId,
                Name = game.Name
            };

            var users = new List<PlayerView>();
            foreach (var entity in input.Players)
            {
                var user = new Player
                {
                    GameId = game.GameId,
                    Name = entity.Name
                };
                _db.Players.Add(user);
                _db.SaveChanges();
                users.Add(new PlayerView {GameId = user.GameId, Name = user.Name, PlayerId = user.PlayerId});
            }

            result.Players = users;

            return View(result);
        }
    }
}