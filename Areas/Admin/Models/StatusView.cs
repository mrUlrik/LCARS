using System;

namespace LCARS.Areas.Admin.Models
{
    public class StatusView
    {
        public int StatusId { get; set; }
        public string TextValue1 { get; set; }
        public string TextValue2 { get; set; }
        public DateTime Time { get; set; }
    }
}
