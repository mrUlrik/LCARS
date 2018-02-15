using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LCARS.Data;

namespace LCARS.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
        public string Slipgate { get; set; }
        public DateTime Created { get; set; }
        public int Round { get; set; }

        public GameStatus Status { get; set; }

        public List<Player> Players { get; set; }
    }
}