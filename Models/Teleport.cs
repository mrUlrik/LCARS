using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Teleport
    {
        [Key]
        public int TeleportId { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public int Round { get; set; }
    }
}
