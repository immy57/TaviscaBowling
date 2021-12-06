using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTavisca
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Frames = new Frame[10];
        }
        public string Name { get; set; }
        public Frame[] Frames { get; set; }
       

    }
}
