namespace LCARS.Models
{
    public class Action
    {
        public int ActionId { get; set; }
        public string Name { get; set; }
        public int SkillId { get; set; }
        public int? LocationId { get; set; }
    }
}
