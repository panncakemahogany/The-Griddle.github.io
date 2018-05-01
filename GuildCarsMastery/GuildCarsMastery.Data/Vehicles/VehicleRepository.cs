using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Parcels.Inventory;

namespace GuildCarsMastery.Data.Vehicles
{
    public class VehicleRepository
    {
        public void AddMake(Manufacturer make)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@ManufacturerId", make.ManufacturerId, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@ManufacturerName", make.ManufacturerName, DbType.AnsiString);
                parameters.Add("@DateAdded", make.DateAdded);
                parameters.Add("@Username", make.Username);

                cn.Execute(
                    "CreateManufacturer",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                make.ManufacturerId = parameters.Get<int>("@ManufacturerId");

                cn.Close();
            }
        }

        public void AddModel(Nameplate model)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@NameplateId", model.NameplateId, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@ManufacturerId", model.ManufacturerId);
                parameters.Add("@NameplateMarque", model.NameplateMarque);
                parameters.Add("@BodyStyle", model.BodyStyle);
                parameters.Add("@DateAdded", model.DateAdded);
                parameters.Add("@Username", model.Username);

                cn.Execute(
                    "CreateNameplate",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                model.NameplateId = parameters.Get<int>("@NameplateId");

                cn.Close();
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@VehicleId", vehicle.VehicleId, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@NameplateId", vehicle.NameplateId);
                parameters.Add("@Mileage", vehicle.Mileage);
                parameters.Add("@Transmission", vehicle.Transmission);
                parameters.Add("@ProductionYear", vehicle.ProductionYear);
                parameters.Add("@VIN", vehicle.VIN);
                parameters.Add("@MSRP", vehicle.MSRP);
                parameters.Add("@SalePrice", vehicle.SalePrice);
                parameters.Add("@ExteriorColor", vehicle.ExteriorColor);
                parameters.Add("@InteriorColor", vehicle.InteriorColor);
                parameters.Add("@Description", vehicle.Description);
                parameters.Add("@ImageFileName", vehicle.ImageFileName);
                parameters.Add("@Featured", vehicle.Featured);

                cn.Execute(
                    "CreateVehicle",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                vehicle.VehicleId = parameters.Get<int>("@VehicleId");

                cn.Close();
            }
        }

        public void DeleteVehicle(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
            }
        }

        public void EditVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@VehicleId", vehicle.VehicleId);
                parameters.Add("@NameplateId", vehicle.NameplateId);
                parameters.Add("@Mileage", vehicle.Mileage);
                parameters.Add("@Transmission", vehicle.Transmission);
                parameters.Add("@ProductionYear", vehicle.ProductionYear);
                parameters.Add("@VIN", vehicle.VIN);
                parameters.Add("@MSRP", vehicle.MSRP);
                parameters.Add("@SalePrice", vehicle.SalePrice);
                parameters.Add("@ExteriorColor", vehicle.ExteriorColor);
                parameters.Add("@InteriorColor", vehicle.InteriorColor);
                parameters.Add("@Description", vehicle.Description);
                parameters.Add("@ImageFileName", vehicle.ImageFileName);
                parameters.Add("@Featured", vehicle.Featured);

                cn.Execute(
                    "UpdateVehicle",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                cn.Close();
            }
        }

        public List<Vehicle> GetInventory(InventoryType type)
        {
            List<Nameplate> models = GetModels();

            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                List<Vehicle> result = new List<Vehicle>();

                using (var multi = cn.QueryMultiple("GetAllVehicles", commandType: CommandType.StoredProcedure))
                {
                    var vehicles = multi.Read<Vehicle>();

                    foreach (var v in vehicles)
                    {
                        result.Add(new Vehicle()
                        {
                            VehicleId = v.VehicleId,
                            Model = models.FirstOrDefault(m => m.NameplateId == v.NameplateId),
                            NameplateId = v.NameplateId,
                            Mileage = v.Mileage,
                            Transmission = v.Transmission,
                            ProductionYear = v.ProductionYear,
                            VIN = v.VIN,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            ExteriorColor = v.ExteriorColor,
                            InteriorColor = v.InteriorColor,
                            Description = v.Description,
                            ImageFileName = v.ImageFileName,
                            Featured = v.Featured
                        });
                    }
                }

                //var query = cn.Query<Vehicle>(
                //    "GetAllVehicles",
                //    commandType: CommandType.StoredProcedure);

                switch (type)
                {
                    case InventoryType.New:
                        return result.Where(v => v.Mileage <= 1000).ToList();
                    case InventoryType.Used:
                        return result.Where(v => v.Mileage > 1000).ToList();
                    default:
                        return result.ToList();
                }
            }
        }

        public List<Manufacturer> GetMakes()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                return cn.Query<Manufacturer>(
                    "GetAllManufacturers",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Nameplate> GetModels()
        {
            List<Manufacturer> makes = GetMakes();

            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                List<Nameplate> result = new List<Nameplate>();

                using (var multi = cn.QueryMultiple("GetAllNameplates", commandType: CommandType.StoredProcedure))
                {
                    var model = multi.Read<Nameplate>();

                    foreach (var m in model)
                    {
                        result.Add(new Nameplate()
                        {
                            NameplateId = m.NameplateId,
                            Manufacturer = makes.FirstOrDefault(t => t.ManufacturerId == m.ManufacturerId),
                            ManufacturerId = m.ManufacturerId,
                            NameplateMarque = m.NameplateMarque,
                            BodyStyle = m.BodyStyle,
                            DateAdded = m.DateAdded,
                            Username = m.Username
                        });
                    }
                }

                return result;

                //var query = cn.Query<Nameplate>(
                //    "GetAllModels",
                //    commandType: CommandType.StoredProcedure);
            }
        }

        public Vehicle GetVehicle(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@VehicleId", id);

                var query = cn.Query<Vehicle>(
                    "GetVehicle",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return query.Single();
            }
        }
    }
}
