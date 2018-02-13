using System.ComponentModel.DataAnnotations;

namespace LCARS.Models
{
    public class Objective
    {
        [Key]
        public int ObjectiveId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
