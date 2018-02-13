using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public int GameId { get; set; }
        public int LocationId { get; set; }
        public int AttributeId { get; set; }

        public string TextValue1 { get; set; }
        public string TextValue2 { get; set; }
    }
}
