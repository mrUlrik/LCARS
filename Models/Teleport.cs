using System;
using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Teleport
    {
        [Key]
        public int TeleportId { get; set; }
        public int GameId { get; set; }
        public DateTime Time { get; set; }
        public int LocationId { get; set; }
        public int Round { get; set; }
        public int PlayerId { get; set; }

        public Location Location { get; set; }
        public Player Player { get; set; }
    }
}
