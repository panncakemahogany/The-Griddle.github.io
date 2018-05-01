using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncrementalGoblinBattle.BLL.DiceRoller
{
    public class Dice
    {
        private static Random rng = new Random();

        public static int Roll20()
        {
            return rng.Next(1, 21);
        }
    }
}
