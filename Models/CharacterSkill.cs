﻿using System.Collections.Generic;

namespace LCARS.Models
{
    public class CharacterSkill
    {
        public int CharacterSkillId { get; set; }
        public int CharacterId { get; set; }
        public int SkillId { get; set; }

        public Character Character { get; set; }
        public Skill Skill { get; set; }
    }
}
