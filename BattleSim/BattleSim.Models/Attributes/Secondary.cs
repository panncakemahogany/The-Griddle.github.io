using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim.Models.Attributes
{
    public class Secondary
    {
        public int ArmorBonus { get; set; }
        public int WeaponBonus { get; set; }
        public int WeaponCritical { get; set; }
        public int Magic { get; set; }
        public int Hitpoints { get; set; }
        public int Stamina { get; set; }
        public int Mana { get; set; }
    }
}
