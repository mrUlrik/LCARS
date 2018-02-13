using System;
using System.Collections.Generic;
using System.Linq;
using LCARS.Areas.Admin.Models;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LCARS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameController : Controller
    {
        private readonly GameContext _db;

        public GameController(GameContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Create(int numPlayers, GameView input)
        {
            if (input == null) return RedirectToAction("Index");
            ViewBag.Characters = new SelectList(_db.Characters.OrderBy(x => x.Name).ToList(), "CharacterId", "Name");
            ViewBag.NumPlayers = numPlayers;

            var game = new GameView {Name = input.Name};
            var players = new List<PlayerView>();
            for (var i = 0; i < numPlayers; i++)
                players.Add(new PlayerView());

            game.Players = players;

            return View(game);
        }

        [HttpPost]
        public IActionResult Insert(GameView input)
        {
            if (input == null) return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                var game = new Game
                {
                    Created = DateTime.Now,
                    IsActive = true,
                    Name = input.Name
                };

                _db.Games.Add(game);
                _db.SaveChanges();

                var players = input.Players.Select(player =>
                    new Player {CharacterId = player.CharacterId, GameId = game.GameId, Name = player.Name}).ToList();
                _db.Players.AddRange(players);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View("Create");
        }

        public IActionResult View(int id)
        {
            var game = _db.Games
                .Select(x =>
                    new GameView {Created = x.Created, GameId = x.GameId, IsActive = x.IsActive, Name = x.Name})
                .Single(x => x.GameId == id);
            var players = _db.Players.Where(x => x.GameId == game.GameId).Include(x => x.Character).Select(x =>
                new PlayerView
                {
                    CharacterId = x.CharacterId,
                    CharacterName = x.Character.Name,
                    GameId = x.GameId,
                    Name = x.Name,
                    PlayerId = x.PlayerId
                }).ToList();
            game.Players = players;

            

            return View(game);
        }
    }
}