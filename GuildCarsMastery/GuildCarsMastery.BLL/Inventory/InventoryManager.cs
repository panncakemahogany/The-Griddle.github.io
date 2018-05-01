using GuildCarsMastery.Data.Purchases;
using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Parcels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.BLL.Inventory
{
    public class InventoryManager
    {
        VehicleRepository vehicleRepo { get; set; }
        PurchaseRepository purchaseRepo { get; set; }

        public InventoryManager()
        {
            vehicleRepo = new VehicleRepository();
            purchaseRepo = new PurchaseRepository();
        }

        public Courier<Vehicle> GetById(int id)
        {
            Courier<Vehicle> courier = new Courier<Vehicle>();

            courier.Package = vehicleRepo.GetInventory(InventoryType.Sales).FirstOrDefault(v => v.VehicleId == id);

            if (courier.Package != null &&
                courier.Package.VehicleId == id)
                courier.Success = true;
            else
            {
                courier.Success = false;
                courier.Message = "Unable to retrieve vehicle by that id";
            }

            return courier;
        }
    }
}
