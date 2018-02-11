using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LCARS.Controllers
{
    public class AdminController : Controller
    {
        private readonly GameContext _db;
        public AdminController(GameContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            
            var character = _db.Characters.FirstOrDefault(u => u.CharacterId == 1);
            ViewBag.Character = character;
            return View();
        }

        public IActionResult Create(GameView input)
        {
            var game = new Game
            {
                Created = DateTime.Now,
                IsActive = true,
                Name = input.Name
            };

            _db.Games.Add(game);

            var result = new GameView
            {
                Created = game.Created,
                GameId = game.GameId,
                Name = game.Name
            };
            _db.SaveChanges();

            var users = new List<UserView>();
            foreach (var entity in input.Users)
            {
                var user = new User()
                {
                    GameId = game.GameId,
                    Name = entity.Name
                };
                _db.Users.Add(user);
                _db.SaveChanges();
                users.Add(new UserView { GameId = user.GameId, Name = user.Name, UserId = user.UserId });
            }

            result.Users = users;

            return View(result);
        }

        
    }
}