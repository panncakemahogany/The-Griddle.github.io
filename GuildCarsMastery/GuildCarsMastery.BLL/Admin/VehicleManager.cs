using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.BLL.Admin
{
    public class VehicleManager
    {
        private VehicleRepository repo { get; set; }

        public VehicleManager()
        {
            repo = new VehicleRepository();
        }

        public Courier<List<Manufacturer>> GetAllMakes()
        {
            Courier<List<Manufacturer>> courier = new Courier<List<Manufacturer>>();

            courier.Package = repo.GetMakes();

            if (courier.Package != null &&
                courier.Package.Count > 0)
            {
                courier.Success = true;
            }
            else
            {
                courier.Success = false;
                courier.Message = "Cannot load makes from database";
            }

            return courier;
        }

        public Courier<List<Nameplate>> GetAllModels()
        {
            Courier<List<Nameplate>> courier = new Courier<List<Nameplate>>();

            courier.Package = repo.GetModels().ToList();

            if (courier.Package != null &&
                courier.Package.Count > 0)
            {
                courier.Success = true;
            }
            else
            {
                courier.Success = false;
                courier.Message = "Cannot load models from database";
            }

            return courier;
        }

        public Courier<List<Nameplate>> GetModelsByMake(Manufacturer make)
        {
            Courier<List<Nameplate>> courier = new Courier<List<Nameplate>>();

            courier.Package = repo.GetModels().Where(m => m.Manufacturer == make).ToList();

            if (courier.Package != null &&
                courier.Package.Count > 0)
            {
                courier.Success = true;
            }
            else
            {
                courier.Success = false;
                courier.Message = "Cannot load models from database";
            }

            return courier;
        }

        public Courier<Manufacturer> CreateNewMake(string newMakeName, string username)
        {
            Courier<Manufacturer> courier = new Courier<Manufacturer>();

            List<Manufacturer> currentMakes = repo.GetMakes();

            foreach (var m in currentMakes)
            {
                if (m.ManufacturerName.ToUpper() == newMakeName.ToUpper())
                    throw new Exception();
            }

            Manufacturer newMake = new Manufacturer()
            {
                ManufacturerName = newMakeName,
                DateAdded = DateTime.Now,
                Username = username
            };

            repo.AddMake(newMake);

            var changedState = repo.GetMakes();

            foreach (var m in changedState)
            {
                if (m.ManufacturerName == newMakeName &&
                    m.Username == username)
                {
                    courier.Success = true;
                    courier.Package = m;
                    return courier;
                }
            }
            courier.Success = false;
            courier.Message = "Add make was unsuccessful at inserting a new make into the database";
            return courier;
        }

        public Courier<Vehicle> CreateNewVehicle(Vehicle newItem)
        {
            Courier<Vehicle> courier = new Courier<Vehicle>();

            newItem.Model = repo.GetModels().FirstOrDefault(n => n.NameplateId == newItem.NameplateId);

            repo.AddVehicle(newItem);

            var check = repo.GetVehicle(newItem.VehicleId);

            if (check != null &&
                check.Description == newItem.Description)
            {
                courier.Package = check;
                courier.Success = true;
            }
            else
                throw new Exception();

            return courier;
        }

        public Courier<Vehicle> UpdateVehicle(Vehicle item)
        {
            Courier<Vehicle> courier = new Courier<Vehicle>();

            item.Model = repo.GetModels().FirstOrDefault(n => n.NameplateId == item.NameplateId);

            repo.EditVehicle(item);

            var check = repo.GetVehicle(item.VehicleId);

            if (check != null &&
                check.Description == item.Description)
            {
                courier.Package = check;
                courier.Success = true;
            }
            else
                throw new Exception();

            return courier;
        }
    }
}
