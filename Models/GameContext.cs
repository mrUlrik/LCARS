using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LCARS.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\games.db");
        }
    }

    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }

        public List<User> Users { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int Name { get; set; }

        public Game Game { get; set; }
    }
}
