﻿using System;
using System.Collections.Generic;

namespace LCARS.Models
{
    public class GameView
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
        
        public List<UserView> Users { get; set; }
    }
}
