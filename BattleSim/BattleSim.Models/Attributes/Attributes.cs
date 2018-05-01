using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim.Models.Attributes
{
    public class Attributes
    {
        public Primary PrimaryAttributes { get; set; }
        public Secondary SecondaryAttributes { get; set; }
        public Tertiary TertiaryAttributes { get; set; }
    }
}
