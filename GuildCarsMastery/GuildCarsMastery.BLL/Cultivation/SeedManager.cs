using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.BLL.Cultivation
{
    public class SeedManager
    {
        private Fertilizer Manure { get; set; }

        public Vehicle PlantACar(int maxNameplateId)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Transmission = Fertilizer.FlipCoin();
            vehicle.Description = ipsum;
            vehicle.Mileage = Fertilizer.GetMileage();
            vehicle.NameplateId = Fertilizer.GetNameplateId(maxNameplateId);
            vehicle.ProductionYear = Fertilizer.GetYear();
            vehicle.MSRP = Fertilizer.GetMSRP();
            vehicle.ExteriorColor = Fertilizer.GetExterior();
            vehicle.InteriorColor = Fertilizer.GetInterior();
            vehicle.Featured = Fertilizer.GetFeaatured();
            if (Fertilizer.FlipCoin() && Fertilizer.FlipCoin())
                vehicle.SalePrice = vehicle.MSRP - 2000;
            else
                vehicle.SalePrice = vehicle.MSRP;
            vehicle.VIN = "TESTCAR1234567890";
            return vehicle;
        }

        public void SetDescriiption(Vehicle vehicle)
        {
            vehicle.Description = ipsum;
        }

        const string ipsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    }
}
