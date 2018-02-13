using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }

        public Game Game { get; set; }
        public Character Character { get; set; }
    }
}