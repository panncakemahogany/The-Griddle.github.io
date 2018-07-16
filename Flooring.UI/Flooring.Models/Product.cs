using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }

        public override string ToString()
        {
            return $"{ProductType}, Cost per square foot = {CostPerSquareFoot}, Labor cost per square foot = {LaborCostPerSquareFoot}";
        }
    }
}
