using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LCARS.Data;

namespace LCARS.Areas.Admin.Models
{
    public class GameView
    {
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Sector { get; set; }
        public string Slipgate { get; set; }

        public DateTime Created { get; set; }
        public int Round { get; set; }

        public GameStatus Status { get; set; }

        public List<PlayerView> Players { get; set; }
    }
}
