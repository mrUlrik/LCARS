using System;
using System.Collections.Generic;
using System.Linq;
using LCARS.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("create")]
        public GameView Create(GameView input)
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

            return result;
        }

        [HttpGet("test/{id}")]
        public List<Character> View(int id)
        {
            var character = _db.Characters.Include(x => x.CharacterSkills).ThenInclude(x => x.Skill).ToList();
            return character;
        }
    }
}