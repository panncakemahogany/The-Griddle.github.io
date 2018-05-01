using GuildCarsMastery.Models.Parcels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models.Reports
{
    public class ReportSalesVM
    {
        public List<SelectListItem> AvailableUsers { get; set; }
        public QuerySalesReportParcel Query { get; set; }
        public List<UserSalesReportParcel> SalesStats { get; set; }
    }
}