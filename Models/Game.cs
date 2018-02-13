using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }

        public List<Player> Players { get; set; }
    }
}