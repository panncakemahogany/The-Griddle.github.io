using Dapper;
using DVDModels.Interfaces;
using DVDModels.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDData
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                if (dvd.Title != null
                        && dvd.RealeaseYear > 0
                        && dvd.Director != null
                        && dvd.Rating != null)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@dvdId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    parameters.Add("@title", dvd.Title);
                    parameters.Add("@realeaseYear", dvd.RealeaseYear);
                    parameters.Add("@director", dvd.Director);
                    parameters.Add("@rating", dvd.Rating);
                    parameters.Add("@notes", dvd.Notes);

                    var cmd = cn.Execute(
                        "AddDvd",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    dvd.DvdId = parameters.Get<int>("@dvdId");

                    cn.Close();
                }
                else
                {
                    cn.Close();
                }
            }
        }

        public void DeleteDvd(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@dvdId", id);

                cn.Execute(
                    "DeleteDvd",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                cn.Close();
            }
        }

        public void EditDvd(Dvd dvd, int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                if (dvd.Title != null
                        && dvd.RealeaseYear > 0
                        && dvd.Director != null
                        && dvd.Rating != null)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@dvdId", dvd.DvdId);
                    parameters.Add("@title", dvd.Title);
                    parameters.Add("@realeaseYear", dvd.RealeaseYear);
                    parameters.Add("@director", dvd.Director);
                    parameters.Add("@rating", dvd.Rating);
                    parameters.Add("@notes", dvd.Notes);


                    cn.Execute(
                        "EditDvd",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    cn.Close();
                }
                else
                {
                    cn.Close();
                }
            }
        }

        public List<Dvd> GetAll()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                return cn.Query<Dvd>(
                    "GetAll",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Dvd> GetByDirector(string director)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@director", director);

                return cn.Query<Dvd>(
                    "GetByDirector",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Dvd GetById(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@dvdId", id);

                return cn.Query<Dvd>(
                    "GetById",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault(d => d.DvdId == id);
            }
        }

        public List<Dvd> GetByRating(string rating)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@rating", rating);

                return cn.Query<Dvd>(
                    "GetByRating",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Dvd> GetByTitle(string title)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@title", title);

                return cn.Query<Dvd>(
                    "GetByTitle",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Dvd> GetByYear(int year)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@realeaseYear", year);

                return cn.Query<Dvd>(
                    "GetByYear",
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
