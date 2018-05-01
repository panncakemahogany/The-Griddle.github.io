using GuildCarsMastery.Data.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.BLL.Sales
{
    public class PurchaseManager
    {
        PurchaseRepository repo { get; set; }

        public PurchaseManager()
        {
            repo = new PurchaseRepository();
        }
    }
}
