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
    public class TestProductRepository : IProductRepository
    {
        private static Product product1 = new Product
        {
            ProductType = "Wood",
            CostPerSquareFoot = 3.5m,
            LaborCostPerSquareFoot = 2.9m
        };
        private static Product product2 = new Product
        {
            ProductType = "Tile",
            CostPerSquareFoot = 1.12m,
            LaborCostPerSquareFoot = 9.99m
        };
        private static Product product3 = new Product
        {
            ProductType = "Linoleum",
            CostPerSquareFoot = .01m,
            LaborCostPerSquareFoot = .02m
        };
        private static List<Product> products = new List<Product>
        {
            product1,
            product2,
            product3
        };

        public List<Product> LoadProducts()
        {
            return products;
        }
    }
}
