using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Parcels.Reports
{
    public class UserSalesReportParcel
    {
        public string Name { get; set; }
        public decimal TotalSales { get; set; }
        public int NumberSold { get; set; }
    }
}
