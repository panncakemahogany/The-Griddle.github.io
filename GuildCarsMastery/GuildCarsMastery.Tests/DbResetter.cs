using GuildCarsMastery.BLL.Cultivation;
using GuildCarsMastery.Data.Contacts;
using GuildCarsMastery.Data.Purchases;
using GuildCarsMastery.Data.Specials;
using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Parcels.Inventory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Tests
{
    [TestFixture]
    public class DbResetter
    {
        [SetUp]
        public void BlankStateDatabase()
        {
            SampleVehicleRepository seedVehicles = new SampleVehicleRepository();
            SampleSpecialRepository seedSpecials = new SampleSpecialRepository();
            SamplePurchaseRepository seedPurchases = new SamplePurchaseRepository();
            SampleContactRepository seedContact = new SampleContactRepository();

            var mSeed = seedVehicles.GetMakes();
            var nSeed = seedVehicles.GetModels();
            var sSeed = seedSpecials.GetSpecials();
            var pSeed = seedPurchases.GetAllPurchases();
            var cSeed = seedContact.GetAll();

            List<Vehicle> vSeed = new List<Vehicle>();
            SeedManager sMgr = new SeedManager();

            for (int i = 0; i < 500; i++)
            {
                var v = sMgr.PlantACar(nSeed.Max(n => n.NameplateId));
                v.Model = nSeed.FirstOrDefault(n => n.NameplateId == v.NameplateId);
                vSeed.Add(v);
            }

            VehicleRepository vRepo = new VehicleRepository();
            SpecialRepository sRepo = new SpecialRepository();
            PurchaseRepository pRepo = new PurchaseRepository();
            ContactRepository cRepo = new ContactRepository();

            foreach (var m in mSeed)
            {
                vRepo.AddMake(m);
            }
            foreach (var n in nSeed)
            {
                n.ManufacturerId = n.Manufacturer.ManufacturerId;
                vRepo.AddModel(n);
            }
            foreach (var v in vSeed)
            {
                if (v.ImageFileName == null || v.ImageFileName.Length < 4)
                {
                    switch (v.Model.BodyStyle)
                    {
                        case BodyStyle.Car:
                            v.ImageFileName = "Car.png";
                            break;
                        case BodyStyle.SUV:
                            v.ImageFileName = "SUV.png";
                            break;
                        case BodyStyle.Truck:
                            v.ImageFileName = "Truck.png";
                            break;
                        case BodyStyle.Van:
                            v.ImageFileName = "Van.png";
                            break;
                        default:
                            throw new Exception("A vehicle's model's body style data was corrupt.");
                    }
                }
                v.NameplateId = v.Model.NameplateId;
                vRepo.AddVehicle(v);
            }
            foreach (var s in sSeed)
            {
                sRepo.AddSpecial(s);
            }
            foreach (var p in pSeed)
            {
                pRepo.AddPurchase(p);
            }
            foreach (var c in cSeed)
            {
                cRepo.Add(c);
            }
        }

        [Test]
        public void CanBlankStateData()
        {
            bool expected = true;
            bool actual = true;
            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //public void CanMapMakesToModels()
        //{
        //    VehicleRepository repo = new VehicleRepository();

        //    var models = repo.GetModels();

        //    bool actual = false;

        //    actual = models.All(m => m.Manufacturer != null);

        //    if (actual)
        //        actual = models.All(m => m.ManufacturerId == m.Manufacturer.ManufacturerId);

        //    Assert.AreEqual(true, actual);
        //}

        //[Test]
        //public void CanMapModelsToVehicles()
        //{
        //    VehicleRepository repo = new VehicleRepository();

        //    var vehicles = repo.GetInventory(InventoryType.Sales);

        //    bool actual = false;

        //    actual = vehicles.All(v => v.Model != null);

        //    if (actual)
        //        actual = vehicles.All(v => v.NameplateId == v.Model.NameplateId);

        //    Assert.AreEqual(true, actual);
        //}
    }
}
