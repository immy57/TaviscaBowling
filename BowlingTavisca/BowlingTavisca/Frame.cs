using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTavisca
{
    public  class Frame
    {
        public Frame()
        {
            Rolls = new List<Roll>();
        }
        public List<Roll> Rolls { get; set; }
        public bool IsStrike { get; set; }

        public bool IsSpare { get; set; }
        public int FrameScore { get; set; }
    }
}
