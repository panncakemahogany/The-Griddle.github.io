using GuildCarsMastery.Models.Parcels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Parcels.Reports
{
    public class VehicleUnitReportParcel
    {
        public InventoryType InventoryType { get; set; }
        public int ProductionYear { get; set; }
        public int NameplateId { get; set; }
        public decimal MSRP { get; set; }
    }
}
