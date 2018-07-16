using Flooring.Models.Interfaces;
using Flooring.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data.FlooringIO
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> LoadOrders(string date)
        {
            List<Order> ordersFromFile = new List<Order>();

            TaxesRepository taxRepo = new TaxesRepository();
            ProductRepository productRepo = new ProductRepository();

            List<Taxes> allTaxes = taxRepo.LoadTaxes();
            List<Product> allProducts = productRepo.LoadProducts();

            using (StreamReader reader = new StreamReader(Settings.GetOrderDateFilePath(date)))
            {
                reader.ReadLine();
                string line;

                while((line = reader.ReadLine()) != null)
                {
                    Order order = new Order();

                    string[] newOrder = line.Split(',');

                    order.OrderNumber = int.Parse(newOrder[0]);
                    order.CustomerName = newOrder[1];

                    foreach (Product p in allProducts)
                    {
                        if (p.ProductType == newOrder[4])
                        {
                            order.Product = p;
                        }
                        else continue;
                    }

                    foreach (Taxes t in allTaxes)
                    {
                        if (t.StateAbbreviation == newOrder[2])
                        {
                            order.Taxes = t;
                        }
                        else continue;
                    }

                    order.Area = decimal.Parse(newOrder[5]);

                    order.CalculateOrderValues(order.CustomerName, order.Area, order.Product, order.Taxes);

                    ordersFromFile.Add(order);
                }
            }

            return ordersFromFile;
        }

        public void SaveOrders(List<Order> orders, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                
                foreach (Order o in orders)
                {
                    writer.WriteLine(o.ToString());
                }
            }
        }
    }
}
