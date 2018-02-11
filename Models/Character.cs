using System.Collections.Generic;

namespace LCARS.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
        public List<CharacterSkill> CharacterSkills { get; set; }
        public List<CharacterObjective> CharacterObjectives { get; set; }
    }
}