using GuildCarsMastery.BLL.Admin;
using GuildCarsMastery.BLL.Inventory;
using GuildCarsMastery.Data.Contacts;
using GuildCarsMastery.Data.Purchases;
using GuildCarsMastery.Data.Specials;
using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models.Admin;
using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models
{
    public class AdminPostmaster
    {
        public static void SetAddUpdateViewModelDropdowns(AdminAddUpdateVehicleVM model)
        {
            model.Makes = SetAvailableMakes();
            model.Models = SetAvailableModels();
            model.Exteriors = SetAvailableExteriorColors();
            model.Interiors = SetAvailableInteriorColors();
            model.Transmissions = SetAvailableTransmissions();
        }

        public static List<SelectListItem> SetAvailableInteriorColors()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Text = "White", Value = "0" },
                new SelectListItem() { Text = "Black", Value = "1" },
                new SelectListItem() { Text = "Beige", Value = "2" },
                new SelectListItem() { Text = "Gray", Value = "3" },
                new SelectListItem() { Text = "Brown", Value = "4" }
            };
        }

        public static List<SelectListItem> SetAvailableExteriorColors()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Text = "White", Value = "0" },
                new SelectListItem() { Text = "Black", Value = "1" },
                new SelectListItem() { Text = "Red", Value = "2" },
                new SelectListItem() { Text = "Blue", Value = "3" },
                new SelectListItem() { Text = "Yellow", Value = "4" },
                new SelectListItem() { Text = "Green", Value = "5" },
                new SelectListItem() { Text = "Silver", Value = "6" },
                new SelectListItem() { Text = "Gold", Value = "7" }
            };
        }

        public static List<SelectListItem> SetAvailableTransmissions()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Automatic", Value = "Automatic" },
                new SelectListItem() { Text = "Manual", Value = "Manual" }
            };
        }

        public static List<SelectListItem> SetAvailableModels()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "Select Make",
                Selected = true
            });

            return list;
        }

        public static List<SelectListItem> SetAvailableMakes()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            VehicleManager mgr = new VehicleManager();

            var makes = mgr.GetAllMakes();

            foreach (var m in makes.Package)
            {
                list.Add(new SelectListItem()
                {
                    Text = m.ManufacturerName,
                    Value = m.ManufacturerId.ToString()
                });
            }

            return list;
        }

        public static void ResetVehicleVM(AdminVehiclesVM model)
        {
            List<SelectListItem> yRange = new List<SelectListItem>();
            List<SelectListItem> pRange = new List<SelectListItem>();
            yRange.Add(new SelectListItem() { Value = "", Text = "No Min", Selected = true });
            pRange.Add(new SelectListItem() { Value = "", Text = "No Min", Selected = true });
            for (int i = 2000; i < 2020; i++)
            {
                yRange.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }
            for (int i = 5000; i < 500000; i += 5000)
            {
                pRange.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }
            model.YearRange = yRange;
            model.PriceRange = pRange;
        }

        public static Courier<Vehicle> GetEditTarget(int id)
        {
            InventoryManager mgr = new InventoryManager();

            return mgr.GetById(id);
        }

        public static Courier<Vehicle> CreateNewVehicle(AdminAddUpdateVehicleVM model)
        {
            VehicleManager mgr = new VehicleManager();

            int nameplateId = int.Parse(model.NameplateId);
            int year = int.Parse(model.ProductionYear);
            int mileage = int.Parse(model.Mileage);
            decimal msrp = decimal.Parse(model.MSRP);
            decimal saleprice = decimal.Parse(model.SalePrice);
            bool trans = model.SelectedTransmission == "Automatic";

            Vehicle newItem = new Vehicle()
            {
                VIN = model.VIN,
                Description = model.Description,
                ImageFileName = model.ImageFileName,
                Featured = model.Featured,
                ExteriorColor = SetExteriorColor(model.BodyColor),
                InteriorColor = SetInteriorColor(model.InteriorColor),
                NameplateId = nameplateId,
                ProductionYear = year,
                Mileage = mileage,
                MSRP = msrp,
                SalePrice = saleprice,
                Transmission = trans
            };

            return mgr.CreateNewVehicle(newItem);
        }

        public static Courier<Vehicle> UpdateVehicle(AdminAddUpdateVehicleVM model)
        {
            VehicleManager mgr = new VehicleManager();

            int vehicleId = int.Parse(model.VehicleId);
            int nameplateId = int.Parse(model.NameplateId);
            int year = int.Parse(model.ProductionYear);
            int mileage = int.Parse(model.Mileage);
            decimal msrp = decimal.Parse(model.MSRP);
            decimal saleprice = decimal.Parse(model.SalePrice);
            bool trans = model.SelectedTransmission == "Automatic";

            Vehicle newItem = new Vehicle()
            {
                VIN = model.VIN,
                Description = model.Description,
                ImageFileName = model.ImageFileName,
                Featured = model.Featured,
                ExteriorColor = SetExteriorColor(model.BodyColor),
                InteriorColor = SetInteriorColor(model.InteriorColor),
                NameplateId = nameplateId,
                ProductionYear = year,
                Mileage = mileage,
                MSRP = msrp,
                SalePrice = saleprice,
                Transmission = trans,
                VehicleId = vehicleId
            };

            return mgr.UpdateVehicle(newItem);
        }

        public static ExteriorColor SetExteriorColor(string id)
        {
            switch (id)
            {
                case "1":
                    return ExteriorColor.Black;
                case "2":
                    return ExteriorColor.Red;
                case "3":
                    return ExteriorColor.Blue;
                case "4":
                    return ExteriorColor.Yellow;
                case "5":
                    return ExteriorColor.Green;
                case "6":
                    return ExteriorColor.Silver;
                case "7":
                    return ExteriorColor.Gold;
                default:
                    return ExteriorColor.White;
            }
        }

        public static InteriorColor SetInteriorColor(string id)
        {
            switch (id)
            {
                case "1":
                    return InteriorColor.Black;
                case "2":
                    return InteriorColor.Beige;
                case "3":
                    return InteriorColor.Gray;
                case "4":
                    return InteriorColor.Brown;
                default:
                    return InteriorColor.White;
            }
        }

        public static Courier<List<Manufacturer>> GetAllMakes()
        {
            VehicleManager mgr = new VehicleManager();

            return mgr.GetAllMakes();
        }

        public static Courier<Manufacturer> CreateNewMake(string newMakeName, string username)
        {
            VehicleManager mgr = new VehicleManager();

            return mgr.CreateNewMake(newMakeName, username);
        }
    }
}