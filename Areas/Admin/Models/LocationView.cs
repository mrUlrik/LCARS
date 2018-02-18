using System.Collections.Generic;

namespace LCARS.Areas.Admin.Models
{
    public class LocationView
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Abbreviated { get; set; }

        public List<AttributeView> Attributes { get; set; }
        public List<TeleportView> Teleports { get; set; }
    }
}
