using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim.Models.Attributes
{
    public class Tertiary
    {
        public string Name { get; set; }
        public RacialType Race { get; set; }
        public ClassType Class { get; set; }
        public int Level { get; set; }
    }
}
