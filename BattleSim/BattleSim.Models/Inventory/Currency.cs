using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSim.Models.Inventory
{
    public class Currency
    {
        public int GoldCoins { get; set; }
        public int SilverCoins { get; set; }
        public int CopperCoins { get; set; }

        public void AddMoney(int gp, int sp, int cp)
        {
            GoldCoins += gp;
            SilverCoins += sp;
            CopperCoins += cp;

            CoinAccounting();
        }

        public void RemoveMoney(int gp, int sp, int cp)
        {
            GoldCoins -= gp;
            SilverCoins -= sp;
            CopperCoins -= cp;

            CoinAccounting();
        }

        public void CoinAccounting()
        {
            while (CopperCoins >= 100)
            {
                SilverCoins += 1;
                CopperCoins -= 100;
            }
            while (SilverCoins >= 100)
            {
                GoldCoins += 1;
                SilverCoins -= 100;
            }
        }
    }
}
