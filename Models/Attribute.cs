using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LCARS.Data;

namespace LCARS.Models
{
    public class Attribute
    {
        [Key]
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public string Abbreviated { get; set; }
        public int? SkillId { get; set; }
        public int? LocationId { get; set; }
        public VariableType VariableType { get; set; }

        public List<Status> Statuses { get; set; }
    }
}
