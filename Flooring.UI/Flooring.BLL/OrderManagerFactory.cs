using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Flooring.Data;
using Flooring.Data.FlooringIO;

namespace Flooring.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepository());
                case "Prod":
                    return new OrderManager(new OrderRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
