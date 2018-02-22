using LCARS.Areas.Admin.Models;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using LCARS.Data;
using Microsoft.AspNetCore.Authorization;

namespace LCARS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
                Name = input.Name,
                Round = 1,
                Status = GameStatus.Running
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
            var record = _db.Games.SingleOrDefault(x => x.GameId == id);
            if (record == null) return RedirectToAction("Index", "Home");

            if (record.Status == GameStatus.NextRound)
            {
                var records = _db.Statuses.Where(x => x.GameId == record.GameId && x.Round == record.Round)
                    .OrderByDescending(x => x.Time).GroupBy(x => new { x.AttributeId, x.LocationId })
                    .Select(x => x.FirstOrDefault()).ToList();

                record.Round++;
                record.Status = GameStatus.Running;
                _db.Games.Update(record);
                _db.SaveChanges();

                var newStatuses = records.Select(status => new Status()
                    {
                        Time = DateTime.Now,
                        GameId = status.GameId,
                        Round = record.Round,
                        LocationId = status.LocationId,
                        AttributeId = status.AttributeId,
                        TextValue1 = status.TextValue1,
                        TextValue2 = status.TextValue2
                    })
                    .ToList();
                _db.Statuses.AddRange(newStatuses);
                _db.SaveChanges();
            }

            var game = new GameView
            {
                Created = record.Created,
                GameId = record.GameId,
                Name = record.Name,
                Round = record.Round,
                Sector = record.Sector,
                Slipgate = record.Slipgate,
                Status = record.Status
            };

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
            var teleports = _db.Teleports.Include(x => x.Player).Where(x => x.GameId == game.GameId && x.Round == game.Round).GroupBy(x => x.Player).Select(x => x.OrderByDescending(y => y.Time).FirstOrDefault()).ToList();
            var statuses = _db.Statuses.Where(x => x.GameId == game.GameId && x.Round == game.Round)
                .OrderByDescending(x => x.Time).GroupBy(x => new { x.AttributeId, x.LocationId })
                .Select(x => x.FirstOrDefault()).ToList();

            var locations = locationAttributes.Select(x => new LocationView
            {
                LocationId = x.LocationId,
                Name = x.Name,
                Status = x.Status,
                Attributes = x.Attributes.Select(y => new AttributeView
                {
                    AttributeId = y.AttributeId,
                    Name = y.Name,
                    Status = statuses.Where(z => z.AttributeId == y.AttributeId).Select(z => new StatusView{StatusId = z.StatusId, TextValue1 = z.TextValue1, TextValue2 = z.TextValue2, Time = z.Time}).SingleOrDefault()
                }).ToList(),
                Teleports = teleports.Where(z => z.LocationId == x.LocationId).Select(z => new TeleportView{PlayerName = z.Player.Name}).ToList()
            }).ToList();
            ViewBag.Locations = locations;

            ViewBag.PlayerActions = _db.PlayerActions.Where(x => x.GameId == game.GameId && x.Round == game.Round).Include(x => x.Attribute).Include(x => x.Location).Include(x => x.Player).ThenInclude(x => x.Character).GroupBy(x => x.Player).Select(x => x.OrderByDescending(t => t.Time).FirstOrDefault());
            
            return View(game);
        }
    }
}