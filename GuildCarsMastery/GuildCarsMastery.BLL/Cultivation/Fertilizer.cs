using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.BLL.Cultivation
{
    public class Fertilizer
    {
        private static Random rng = new Random();

        public static int GetYear()
        {
            return rng.Next(2000, 2020);
        }

        public static int GetNameplateId(int maxNameplateId)
        {
            maxNameplateId++;

            return rng.Next(1, maxNameplateId);
        }

        public static ExteriorColor GetExterior()
        {
            int number = rng.Next(0, 8);

            switch (number)
            {
                case 1:
                    return ExteriorColor.Black;
                case 2:
                    return ExteriorColor.Red;
                case 3:
                    return ExteriorColor.Blue;
                case 4:
                    return ExteriorColor.Yellow;
                case 5:
                    return ExteriorColor.Green;
                case 6:
                    return ExteriorColor.Silver;
                case 7:
                    return ExteriorColor.Gold;
                default:
                    return ExteriorColor.White;
            }
        }

        public static InteriorColor GetInterior()
        {
            int number = rng.Next(0, 5);

            switch (number)
            {
                case 1:
                    return InteriorColor.Black;
                case 2:
                    return InteriorColor.Beige;
                case 3:
                    return InteriorColor.Gray;
                case 4:
                    return InteriorColor.Brown;
                default:
                    return InteriorColor.White;
            }
        }

        public static decimal GetMSRP()
        {
            int x = rng.Next(1, 201);

            return decimal.Parse((x * 2500).ToString());
        }

        public static int GetMileage()
        {
            return rng.Next(0, 300000);
        }

        public static bool FlipCoin()
        {
            int x = rng.Next(0, 2);

            return x == 1;
        }

        public static bool GetFeaatured()
        {
            return rng.Next(0, 51) < 4;
        }
    }
}
