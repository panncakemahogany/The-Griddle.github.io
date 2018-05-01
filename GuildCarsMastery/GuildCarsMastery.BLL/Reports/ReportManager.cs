using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Parcels.Inventory;
using GuildCarsMastery.Models.Parcels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.BLL.Reports
{
    public class ReportManager
    {
        public Courier<VehicleUnitReportParcel> GetVehicleAccount(Vehicle vehicle)
        {
            Courier<VehicleUnitReportParcel> courier = new Courier<VehicleUnitReportParcel>();

            VehicleUnitReportParcel parcel = new VehicleUnitReportParcel()
            {
                NameplateId = vehicle.NameplateId,
                ProductionYear = vehicle.ProductionYear,
                MSRP = vehicle.MSRP
            };

            if (vehicle.Mileage > 1000)
                parcel.InventoryType = InventoryType.Used;
            else
                parcel.InventoryType = InventoryType.New;

            courier.Package = parcel;

            return courier;
        }
    }
}
