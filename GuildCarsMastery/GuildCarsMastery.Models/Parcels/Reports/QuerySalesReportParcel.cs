using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Parcels.Reports
{
    public class QuerySalesReportParcel
    {
        public string User { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
    }
}
