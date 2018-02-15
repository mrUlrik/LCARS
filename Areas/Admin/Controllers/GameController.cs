﻿using System;
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

            var teleports = new[]
            {
                new Teleport { GameId = 1, LocationId = 2, Round = 1, PlayerId = 1},
                new Teleport { GameId = 1, LocationId = 2, Round = 1, PlayerId = 2},
                new Teleport { GameId = 1, LocationId = 2, Round = 1, PlayerId = 3}
            };
            _db.Teleports.AddRange(teleports);
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

            var locationAttributes = _db.Locations.Include(x => x.Attributes).ToList();
            var teleports = _db.Teleports.Include(x => x.Player).Where(x => x.GameId == game.GameId && x.Round == game.Round).ToList();
            var statuses = _db.Statuses.Where(x => x.GameId == game.GameId && x.Round == game.Round)
                .OrderByDescending(x => x.Time).GroupBy(x => new { x.AttributeId, x.LocationId })
                .Select(x => x.FirstOrDefault()).ToList();

            var locations = locationAttributes.Select(x => new LocationView
            {
                LocationId = x.LocationId,
                Name = x.Name,
                Attributes = x.Attributes.Select(y => new AttributeView
                {
                    AttributeId = y.AttributeId,
                    Name = y.Name,
                    Status = statuses.Where(z => z.AttributeId == y.AttributeId).Select(z => new StatusView{StatusId = z.StatusId, TextValue1 = z.TextValue1, TextValue2 = z.TextValue2, Time = z.Time}).SingleOrDefault()
                }).ToList(),
                Teleports = teleports.Where(z => z.LocationId == x.LocationId).Select(z => new TeleportView{PlayerName = z.Player.Name}).ToList()
            }).ToList();
            ViewBag.Locations = locations;
            
            return View(game);
        }
    }
}