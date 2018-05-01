using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Domain.Business;
using System.Data;

namespace GuildCarsMastery.Data.Specials
{
    public class SpecialRepository
    {
        public void AddSpecial(Special special)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@SpecialId", special.SpecialId, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@SpecialTitle", special.SpecialTitle);
                parameters.Add("@SpecialInformation", special.SpecialInformation);

                cn.Execute(
                    "CreateSpecial",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                special.SpecialId = parameters.Get<int>("@SpecialId");

                cn.Close();
            }
        }

        public void DeleteSpecial(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
            }
        }

        public List<Special> GetSpecials()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                return cn.Query<Special>(
                    "GetAllSpecials",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
