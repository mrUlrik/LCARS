using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }

        public List<Attribute> Attributes { get; set; }
        public List<Teleport> Teleports { get; set; }
    }
}
