using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LCARS.Data;

namespace LCARS.Models
{
    public class PlayerAction
    {
        [Key]
        public int PlayerActionId { get; set; }
        public DateTime Time { get; set; }
        public int GameId { get; set; }
        public int Round { get; set; }
        public int PlayerId { get; set; }
        public int LocationId { get; set; }
        public int AttributeId { get; set; }
        public string On { get; set; }

        public Player Player { get; set; }
        public Location Location { get; set; }
        public Attribute Attribute { get; set; }
    }
}
