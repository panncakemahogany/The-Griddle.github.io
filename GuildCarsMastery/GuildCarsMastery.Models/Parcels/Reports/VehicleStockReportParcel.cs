using GuildCarsMastery.Models.Parcels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Parcels.Reports
{
    public class VehicleStockReportParcel
    {
        public InventoryType InventoryType { get; set; }
        public int ProductionYear { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public int NameplateId { get; set; }
        public string NameplateMarque { get; set; }
        public int NumberInStock { get; set; }
        public decimal GrossValue { get; set; }
    }
}
