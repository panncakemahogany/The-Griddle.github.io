using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riley.Powerball.BLL
{
    public class Pick
    {
        public int Identifier { get; set; }
        public string Name { get; set; }
        public int FirstBall { get; set; }
        public int SecondBall { get; set; }
        public int ThirdBall { get; set; }
        public int FourthBall { get; set; }
        public int FifthBall { get; set; }
        public int PowerBall { get; set; }
        public int WinningBallCount { get; set; }
        public bool WinningPowerball { get; set; }
        public decimal Winnings { get; set; }

        public Pick()
        {
            
        }

        public override string ToString()
        {
            string result = $"{Identifier},{Name},{FirstBall},{SecondBall},{ThirdBall},{FourthBall},{FifthBall},{PowerBall}";
            return result;
        }
    }
}
