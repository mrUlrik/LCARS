using System.Collections.Generic;

namespace LCARS.Models
{
    public class GameOverview
    {
        public Game Game { get; set; }
        public List<User> Users { get; set; }
    }
}
