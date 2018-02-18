using LCARS.Models;

namespace LCARS.Areas.Admin.Models
{
    public class AttributeView
    {
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public string Abbreviated { get; set; }

        public StatusView Status { get; set; }
    }
}
