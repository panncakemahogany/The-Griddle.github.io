using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Flooring.Data;
using Flooring.Data.FlooringIO;
using Flooring.Models.Interfaces;

namespace Flooring.BLL
{
    public class TaxesRepositoryFactory
    {
        public static ITaxesRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new TestTaxesRepository();
                case "Prod":
                    return new TaxesRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
