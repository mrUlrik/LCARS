using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
    }
}
