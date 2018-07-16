using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public Product Product { get; set; }
        public Taxes Taxes { get; set; }

        public Order()
        {

        }

        public void CalculateOrderValues(string name, decimal area, Product product, Taxes taxes)
        {
            Product = product;
            Taxes = taxes;
            CustomerName = name;
            Area = area;
            ProductType = product.ProductType;
            CostPerSquareFoot = product.CostPerSquareFoot;
            LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
            State = taxes.StateAbbreviation;
            TaxRate = taxes.TaxRate;

            MaterialCost = GetMaterialCost(area, product);
            LaborCost = GetLaborCost(area, product);
            Tax = GetTax(MaterialCost, LaborCost, taxes);
            Total = GetTotal(MaterialCost, LaborCost, Tax);
        }

        private static decimal GetMaterialCost(decimal area, Product product)
        {
            decimal materialCost = area * product.CostPerSquareFoot;
            return materialCost;
        }

        private static decimal GetLaborCost(decimal area, Product product)
        {
            decimal laborCost = area * product.LaborCostPerSquareFoot;
            return laborCost;
        }

        private static decimal GetTax(decimal materialCost, decimal laborCost, Taxes taxes)
        {
            decimal tax = (materialCost + laborCost) * (taxes.TaxRate / 100);
            string rounder = $"{tax:C}";
            tax = decimal.Parse(rounder.Remove(0, 1));
            return tax;
        }

        private static decimal GetTotal(decimal materialCost, decimal laborCost, decimal tax)
        {
            decimal total = materialCost + laborCost + tax;
            return total;
        }

        public void DisplayOrdersFormat(string date)
        {
            Console.WriteLine("******************************************************************");
            Console.WriteLine($"{OrderNumber} | {date}");
            Console.WriteLine(CustomerName);
            Console.WriteLine(State);
            Console.WriteLine("Product : " + ProductType);
            Console.WriteLine("Materials : $" + MaterialCost);
            Console.WriteLine("Labor : $" + LaborCost);
            Console.WriteLine("Tax : $" + Tax);
            Console.WriteLine("Total : $" + Total);
            Console.WriteLine("******************************************************************");
        }

        public void AddOrderFormat()
        {
            Console.WriteLine("Name : " + CustomerName);
            Console.WriteLine("State : " + State);
            Console.WriteLine("Tax rate : " + TaxRate);
            Console.WriteLine("Product : " + ProductType);
            Console.WriteLine("Area : " + Area);
            Console.WriteLine("Product's cost per square foot : " + CostPerSquareFoot);
            Console.WriteLine("Labor cost per square foor : " + LaborCostPerSquareFoot);
            Console.WriteLine("Materials : $" + MaterialCost);
            Console.WriteLine("Labor : $" + LaborCost);
            Console.WriteLine("Tax : $" + Tax);
            Console.WriteLine("Total : $" + Total);
        }

        public void DynamicDisplayFormat()
        {
            Console.Clear();
            Console.WriteLine("Order number : " +OrderNumber);
            Console.WriteLine("Name : " + CustomerName);
            Console.WriteLine("State : " + State);
            Console.WriteLine("Tax rate : " + TaxRate);
            Console.WriteLine("Product : " + ProductType);
            Console.WriteLine("Area : " + Area);
            Console.WriteLine("Product's cost per square foot : " + CostPerSquareFoot);
            Console.WriteLine("Labor cost per square foor : " + LaborCostPerSquareFoot);
            Console.WriteLine("Materials : $" + MaterialCost);
            Console.WriteLine("Labor : $" + LaborCost);
            Console.WriteLine("Tax : $" + Tax);
            Console.WriteLine("Total : $" + Total);
        }

        public override string ToString()
        {
            string toFile = $"{OrderNumber},{CustomerName},{State},{TaxRate},{ProductType},{Area},{CostPerSquareFoot},{LaborCostPerSquareFoot},{MaterialCost},{LaborCost},{Tax},{Total}";
            return toFile;
        }
    }
}
