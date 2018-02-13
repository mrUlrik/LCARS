using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LCARS.Areas.Admin.Models
{
    public class GameView
    {
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
        public int Round { get; set; }

        public List<PlayerView> Players { get; set; }
    }
}
