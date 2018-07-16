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
    public class ProductRepositoryFactory
    {
        public static IProductRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new TestProductRepository();
                case "Prod":
                    return new ProductRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
