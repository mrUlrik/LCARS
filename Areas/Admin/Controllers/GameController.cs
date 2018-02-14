using System;
using System.Collections.Generic;
using System.Linq;
using LCARS.Areas.Admin.Models;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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

            if (!ModelState.IsValid) return View("Create");

            var game = new Game
            {
                Created = DateTime.Now,
                IsActive = true,
                Name = input.Name,
                Round = 1
            };

            _db.Games.Add(game);
            _db.SaveChanges();

            var players = input.Players.Select(player =>
                new Player {CharacterId = player.CharacterId, GameId = game.GameId, Name = player.Name}).ToList();
            _db.Players.AddRange(players);
            _db.SaveChanges();

            var statuses = _db.Attributes.Select(attribute => new Status {AttributeId = attribute.AttributeId, GameId = game.GameId, Round = game.Round, LocationId = attribute.LocationId, TextValue1 = "", TextValue2 = "", Time = DateTime.Now}).ToList();
            _db.Statuses.AddRange(statuses);

            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Manage(int id)
        {
            var game = _db.Games
                .Select(x =>
                    new GameView
                    {
                        Created = x.Created,
                        GameId = x.GameId,
                        IsActive = x.IsActive,
                        Name = x.Name,
                        Round = x.Round
                    })
                .SingleOrDefault(x => x.GameId == id && x.IsActive);
            if (game == null) return RedirectToAction("Index", "Home");

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

            var statuses = new List<Status>();
            var query = _db.Statuses.Where(x => x.GameId == game.GameId && x.Round == game.Round)
                .OrderByDescending(x => x.Time).GroupBy(x => new {x.AttributeId, x.LocationId})
                .Select(x => x.FirstOrDefault());
            if (query.Any())
                statuses = query.ToList();
            ViewBag.Statuses = statuses;

            var locations = _db.Locations.Include(x => x.Attributes).Select(x => new LocationView
            {
                LocationId = x.LocationId,
                Name = x.Name,
                Attributes = x.Attributes.Select(y => new AttributeView
                {
                    AttributeId = y.AttributeId,
                    Name = y.Name
                }).ToList()
            }).ToList();

            var blah = new List<StatusView>();
            var query2 = _db.Statuses.Where(x => x.GameId == game.GameId && x.Round == game.Round).OrderByDescending(x => x.Time).GroupBy(x => x.Time).Select(x => x.FirstOrDefault());
            if (query2.Any())
                blah = blah.ToList();

            var result = locations.Select(x => new LocationView
            {
                LocationId = x.LocationId, Name = x.Name,
                Attributes = query2.Select(y => new StatusView{StatusId = y.StatusId, TextValue1 = y.TextValue1, TextValue2 = y.TextValue2, Time = y.Time}).FirstOrDefault(y => y.LocationId == x.LocationId);
            })
            ViewBag.Locations = locations;

            
            return View(game);
        }
    }
}