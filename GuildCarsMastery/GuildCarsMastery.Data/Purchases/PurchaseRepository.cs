using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCarsMastery.Models.Domain.Business;
using System.Data;

namespace GuildCarsMastery.Data.Purchases
{
    public class PurchaseRepository
    {
        public void AddPurchase(Purchase purchase)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@PurchaseId", purchase.PurchaseId, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Username", purchase.Username);
                parameters.Add("@VehicleId", purchase.VehicleId);
                parameters.Add("@CustomerName", purchase.CustomerName);
                parameters.Add("@CustomerPhone", purchase.CustomerPhone);
                parameters.Add("@CustomerEmail", purchase.CustomerEmail);
                parameters.Add("@CustomerStreet1", purchase.CustomerStreet1);
                parameters.Add("@CustomerStreet2", purchase.CustomerStreet2);
                parameters.Add("@CustomerCity", purchase.CustomerCity);
                parameters.Add("@CustomerStateId", purchase.CustomerStateId);
                parameters.Add("@CustomerZipcode", purchase.CustomerZipcode);
                parameters.Add("@PurchasePrice", purchase.PurchasePrice);
                parameters.Add("@PurchaseTypeId", purchase.PurchaseTypeId);

                cn.Execute(
                    "CreatePurchase",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                purchase.PurchaseId = parameters.Get<int>("@PurchaseId");

                cn.Close();
            }
        }

        public List<Purchase> GetAllPurchases()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                return cn.Query<Purchase>(
                    "GetAllPurchases",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
