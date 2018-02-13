using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string Name { get; set; }
    }
}
