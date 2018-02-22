using System.Collections.Generic;

namespace LCARS.Areas.Admin.Models
{
    public class CharacterView
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Story { get; set; }
        public string TraitName { get; set; }
        public string TraitDescription { get; set; }
        public string Tips { get; set; }

        public List<Checkbox> Skills { get; set; }
        public List<Checkbox> Objectives { get; set; }
    }
}