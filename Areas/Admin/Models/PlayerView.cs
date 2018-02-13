using System.ComponentModel.DataAnnotations;

namespace LCARS.Areas.Admin.Models
{
    public class PlayerView
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }

        [Required]
        public int CharacterId { get; set; }

        [StringLength(64, MinimumLength = 3)]
        public string Name { get; set; }

        public string CharacterName { get; set; }
    }
}
