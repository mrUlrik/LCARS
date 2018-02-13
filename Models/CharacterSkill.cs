using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class CharacterSkill
    {
        [Key]
        public int CharacterSkillId { get; set; }
        public int CharacterId { get; set; }
        public int SkillId { get; set; }

        public Character Character { get; set; }
        public Skill Skill { get; set; }
    }
}
