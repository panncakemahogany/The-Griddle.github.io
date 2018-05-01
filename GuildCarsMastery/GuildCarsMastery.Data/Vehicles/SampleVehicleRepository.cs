using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Domain.Vehicle;

namespace GuildCarsMastery.Data.Vehicles
{
    public class SampleVehicleRepository
    {
        static List<Manufacturer> availableMakes = new List<Manufacturer>
        {
            new Manufacturer {ManufacturerId = 1, ManufacturerName = "Toyota", DateAdded = DateTime.Now, Username = "test1"},
            new Manufacturer {ManufacturerId = 2, ManufacturerName = "Honda", DateAdded = DateTime.Now.AddMinutes(-30), Username = "test1"},
            new Manufacturer {ManufacturerId = 3, ManufacturerName = "Ford", DateAdded = DateTime.Now.AddHours(-300), Username = "test1"},
            new Manufacturer {ManufacturerId = 4, ManufacturerName = "Dodge", DateAdded = DateTime.Now.AddDays(-30), Username = "test1"},
            new Manufacturer {ManufacturerId = 5, ManufacturerName = "Chevrolet", DateAdded = DateTime.Now.AddMonths(-6), Username = "test1"}
        };

        static List<Nameplate> availableModels = new List<Nameplate>
        {
            new Nameplate {NameplateId = 1, Manufacturer = availableMakes[0], BodyStyle = BodyStyle.Car, NameplateMarque = "Corolla", DateAdded = DateTime.Now, Username = "test1"},
            new Nameplate {NameplateId = 2, Manufacturer = availableMakes[0], BodyStyle = BodyStyle.Car, NameplateMarque = "Camry", DateAdded = DateTime.Now, Username = "test1"},
            new Nameplate {NameplateId = 3, Manufacturer = availableMakes[1], BodyStyle = BodyStyle.Car, NameplateMarque = "Civic", DateAdded = DateTime.Now.AddMinutes(-30), Username = "test1"},
            new Nameplate {NameplateId = 4, Manufacturer = availableMakes[1], BodyStyle = BodyStyle.Car, NameplateMarque = "Accord", DateAdded = DateTime.Now.AddMinutes(-30), Username = "test1"},
            new Nameplate {NameplateId = 5, Manufacturer = availableMakes[2], BodyStyle = BodyStyle.Car, NameplateMarque = "Mustang", DateAdded = DateTime.Now.AddHours(-300), Username = "test1"},
            new Nameplate {NameplateId = 6, Manufacturer = availableMakes[2], BodyStyle = BodyStyle.Car, NameplateMarque = "Taurus", DateAdded = DateTime.Now.AddHours(-300), Username = "test1"},
            new Nameplate {NameplateId = 7, Manufacturer = availableMakes[3], BodyStyle = BodyStyle.Car, NameplateMarque = "Charger", DateAdded = DateTime.Now.AddDays(-30), Username = "test1"},
            new Nameplate {NameplateId = 8, Manufacturer = availableMakes[3], BodyStyle = BodyStyle.Car, NameplateMarque = "Challenger", DateAdded = DateTime.Now.AddDays(-30), Username = "test1"},
            new Nameplate {NameplateId = 9, Manufacturer = availableMakes[4], BodyStyle = BodyStyle.Car, NameplateMarque = "Camaro", DateAdded = DateTime.Now.AddMonths(-6), Username = "test1"},
            new Nameplate {NameplateId = 10, Manufacturer = availableMakes[4], BodyStyle = BodyStyle.Car, NameplateMarque = "Impala", DateAdded = DateTime.Now.AddMonths(-6), Username = "test1"}
        };

        static string ipsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        static List<Vehicle> vehicleInventory = new List<Vehicle>
        {
            new Vehicle {VehicleId = 1, Model = availableModels[0], Mileage = 0, Transmission = true, ProductionYear = 2017,
                        VIN = "1FTPE24L6XHC64805", MSRP = 22000, SalePrice = 20000, ExteriorColor = ExteriorColor.Silver, InteriorColor = InteriorColor.Gray,
                        Description = ipsum, Featured = true},
            new Vehicle {VehicleId = 2, Model = availableModels[1], Mileage = 10000, Transmission = true, ProductionYear = 2016,
                        VIN = "KM8JN12D26U283378", MSRP = 60000, SalePrice = 58000, ExteriorColor = ExteriorColor.Silver, InteriorColor = InteriorColor.White,
                        Description = ipsum, Featured = true},
            new Vehicle {VehicleId = 3, Model = availableModels[2], Mileage = 0, Transmission = true, ProductionYear = 2015,
                        VIN = "5HD1JDB165Y167560", MSRP = 35000, SalePrice = 35000, ExteriorColor = ExteriorColor.Black, InteriorColor = InteriorColor.Beige,
                        Description = ipsum, Featured = false},
            new Vehicle {VehicleId = 4, Model = availableModels[3], Mileage = 0, Transmission = true, ProductionYear = 2018,
                        VIN = "1MEBM36X1PK699977", MSRP = 45000, SalePrice = 43000, ExteriorColor = ExteriorColor.Blue, InteriorColor = InteriorColor.Black,
                        Description = ipsum, Featured = true},
            new Vehicle {VehicleId = 5, Model = availableModels[4], Mileage = 0, Transmission = true, ProductionYear = 2019,
                        VIN = "1FMCU24X9PUD38399", MSRP = 50000, SalePrice = 48000, ExteriorColor = ExteriorColor.Gold, InteriorColor = InteriorColor.Brown,
                        Description = ipsum, Featured = true},
            new Vehicle {VehicleId = 6, Model = availableModels[5], Mileage = 10000, Transmission = true, ProductionYear = 2014,
                        VIN = "1FABP30X3LK225952", MSRP = 45000, SalePrice = 45000, ExteriorColor = ExteriorColor.Green, InteriorColor = InteriorColor.Gray,
                        Description = ipsum, Featured = false},
            new Vehicle {VehicleId = 7, Model = availableModels[6], Mileage = 0, Transmission = true, ProductionYear = 2013,
                        VIN = "2FMDA56402BA59309", MSRP = 60000, SalePrice = 58000, ExteriorColor = ExteriorColor.Red, InteriorColor = InteriorColor.White,
                        Description = ipsum, Featured = true},
            new Vehicle {VehicleId = 8, Model = availableModels[7], Mileage = 0, Transmission = true, ProductionYear = 2016,
                        VIN = "1HGCS2A89AA053669", MSRP = 33000, SalePrice = 31000, ExteriorColor = ExteriorColor.Silver, InteriorColor = InteriorColor.Beige,
                        Description = ipsum, Featured = true},
            new Vehicle {VehicleId = 9, Model = availableModels[8], Mileage = 0, Transmission = true, ProductionYear = 2015,
                        VIN = "1G6AB6989D9188662", MSRP = 70000, SalePrice = 70000, ExteriorColor = ExteriorColor.White, InteriorColor = InteriorColor.Black,
                        Description = ipsum, Featured = false},
            new Vehicle {VehicleId = 10, Model = availableModels[9], Mileage = 250000, Transmission = true, ProductionYear = 2018,
                        VIN = "1D8HD48P89F726362", MSRP = 35000, SalePrice = 33000, ExteriorColor = ExteriorColor.Yellow, InteriorColor = InteriorColor.Brown,
                        Description = ipsum, Featured = true},
            new Vehicle {VehicleId = 11, Model = availableModels[0], Mileage = 300000, Transmission = false, ProductionYear = 2017,
                        VIN = "2WKPDCFF1RK996857", MSRP = 1000000, SalePrice = 1000000, ExteriorColor = ExteriorColor.Black, InteriorColor = InteriorColor.Gray,
                        Description = ipsum, Featured = false},
            new Vehicle {VehicleId = 12, Model = availableModels[1], Mileage = 0, Transmission = false, ProductionYear = 2017,
                        VIN = "4V2DCFMD0MU651391", MSRP = 25000, SalePrice = 23000, ExteriorColor = ExteriorColor.Blue, InteriorColor = InteriorColor.White,
                        Description = ipsum, Featured = true},
            new Vehicle {VehicleId = 13, Model = availableModels[7], Mileage = 0, Transmission = false, ProductionYear = 2013,
                        VIN = "4JGDA7EB7EA271460", MSRP = 40000, SalePrice = 38000, ExteriorColor = ExteriorColor.Gold, InteriorColor = InteriorColor.Black,
                        Description = ipsum, Featured = true},
            new Vehicle {VehicleId = 14, Model = availableModels[6], Mileage = 0, Transmission = false, ProductionYear = 2014,
                        VIN = "WD8PE746475165607", MSRP = 50000, SalePrice = 50000, ExteriorColor = ExteriorColor.Green, InteriorColor = InteriorColor.Beige,
                        Description = ipsum, Featured = false},
            new Vehicle {VehicleId = 15, Model = availableModels[4], Mileage = 15000, Transmission = false, ProductionYear = 2019,
                        VIN = "SMTE06BF8CJ572718", MSRP = 65000, SalePrice = 65000, ExteriorColor = ExteriorColor.Red, InteriorColor = InteriorColor.Brown,
                        Description = ipsum, Featured = false},
            new Vehicle {VehicleId = 16, Model = availableModels[0], Mileage = 20000, Transmission = true, ProductionYear = 2013,
                        VIN = "JHMAR6523GC023352", MSRP = 45000, SalePrice = 43000, ExteriorColor = ExteriorColor.Silver, InteriorColor = InteriorColor.Gray,
                        Description = ipsum, Featured = false},
            new Vehicle {VehicleId = 17, Model = availableModels[3], Mileage = 0, Transmission = false, ProductionYear = 2015,
                        VIN = "WDBJH82F6XX012036", MSRP = 60000, SalePrice = 60000, ExteriorColor = ExteriorColor.White, InteriorColor = InteriorColor.White,
                        Description = ipsum, Featured = false},
            new Vehicle {VehicleId = 18, Model = availableModels[8], Mileage = 5000, Transmission = true, ProductionYear = 2017,
                        VIN = "1GDE4E1285F534953", MSRP = 50000, SalePrice = 49500, ExteriorColor = ExteriorColor.Yellow, InteriorColor = InteriorColor.Black,
                        Description = ipsum, Featured = false}
        };

        public List<Vehicle> GetInventory()
        {
            return vehicleInventory;
        }

        public List<Manufacturer> GetMakes()
        {
            return availableMakes;
        }

        public List<Nameplate> GetModels()
        {
            return availableModels;
        }
    }
}
