using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerballMVC.Models
{
    public class Ticket
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string FirstBall { get; set; }
        public string SecondBall { get; set; }
        public string ThirdBall { get; set; }
        public string FourthBall { get; set; }
        public string FifthBall { get; set; }
        public string PowerBall { get; set; }
        public int WinningBallCount { get; set; }
        public bool WinningPowerball { get; set; }
        public decimal Winnings { get; set; }

        public Ticket()
        {

        }

        public override string ToString()
        {
            string result = $"{Identifier},{Name},{FirstBall},{SecondBall},{ThirdBall},{FourthBall},{FifthBall},{PowerBall}";
            return result;
        }
    }
}