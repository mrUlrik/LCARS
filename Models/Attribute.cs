using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Attribute
    {
        [Key]
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public int? SkillId { get; set; }
        public int? LocationId { get; set; }

        public List<Status> Statuses { get; set; }
    }
}
