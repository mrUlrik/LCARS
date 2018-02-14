using System.Collections.Generic;

namespace LCARS.Areas.Admin.Models
{
    public class LocationView
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        public List<AttributeView> Attributes { get; set; }
    }
}
