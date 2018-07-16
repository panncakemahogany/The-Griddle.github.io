using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using Flooring.Models.Interfaces;
using System.IO;

namespace Flooring.Data.FlooringIO
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> LoadProducts()
        {
            List<Product> allProducts = new List<Product>();

            using (StreamReader reader = new StreamReader(Settings.ProductListFilePath))
            {
                reader.ReadLine();
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Product newProduct = new Product();
                    string[] product = line.Split(',');

                    newProduct.ProductType = product[0];
                    newProduct.CostPerSquareFoot = decimal.Parse(product[1]);
                    newProduct.LaborCostPerSquareFoot = decimal.Parse(product[2]);

                    allProducts.Add(newProduct);
                }
            }

            return allProducts;
        }
    }
}
