using GuildCarsMastery.Models.Domain.Business;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GuildCarsMastery.Data.Contacts
{
    public class ContactRepository
    {
        public void Add(ContactUs contact)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@SubmissionId", contact.SubmissionId, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@ContactName", contact.ContactName);
                parameters.Add("@ContactEmail", contact.ContactEmail);
                parameters.Add("@ContactPhone", contact.ContactPhone);
                parameters.Add("@ContactMessage", contact.ContactMessage);
                parameters.Add("@SubmissionDate", contact.SubmissionDate);

                cn.Execute(
                    "CreateContact",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                contact.SubmissionId = parameters.Get<int>("@SubmissionId");

                cn.Close();
            }
        }

        public List<ContactUs> GetAll()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                return cn.Query<ContactUs>(
                    "GetAllContactSubmissions",
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public ContactUs GetById(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["GuildCars"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@SubmissionId", id);

                return cn.Query<ContactUs>(
                    "GetContactSubmission",
                    parameters,
                    commandType: CommandType.StoredProcedure).Single();
            }
        }
    }
}
