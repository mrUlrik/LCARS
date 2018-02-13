using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class CharacterObjective
    {
        [Key]
        public int CharacterObjectiveId { get; set; }
        public int CharacterId { get; set; }
        public int ObjectiveId { get; set; }

        public Character Character { get; set; }
        public Objective Objective { get; set; }
    }
}
