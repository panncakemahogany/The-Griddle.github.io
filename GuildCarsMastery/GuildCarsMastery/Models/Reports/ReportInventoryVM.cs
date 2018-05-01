using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCarsMastery.Models.Reports
{
    public class ReportInventoryVM
    {
        List<string> NewVehicles { get; set; }
        List<string> UserVehicles { get; set; }
    }
}