using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data.FlooringIO;
using Flooring.Models;
using Flooring.Models.Interfaces;
using System.IO;

namespace Flooring.Data.FlooringIO
{
    public class TestOrderRepository : IOrderRepository
    {
        private static Order first = new Order
        {
            OrderNumber = 1,
            CustomerName = "Jack Jackson",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Carpet",
            CostPerSquareFoot = 2.25m,
            LaborCostPerSquareFoot = 2.10m,
            Area = 100,
            MaterialCost = 225,
            LaborCost = 210,
            Tax = 27.19m,
            Total = 462.19m
        };
        private static Order second = new Order
        {
            OrderNumber = 2,
            CustomerName = "John Johnson",
            State = "PA",
            TaxRate = 6.75M,
            ProductType = "Laminate",
            CostPerSquareFoot = 1.75m,
            LaborCostPerSquareFoot = 2.10m,
            Area = 200,
            MaterialCost = 350,
            LaborCost = 420,
            Tax = 51.98m,
            Total = 821.98m
        };
        private static Order third = new Order
        {
            OrderNumber = 3,
            CustomerName = "Erik Erikson",
            State = "MI",
            TaxRate = 5.75M,
            ProductType = "Tile",
            CostPerSquareFoot = 3.50m,
            LaborCostPerSquareFoot = 4.15m,
            Area = 250,
            MaterialCost = 875,
            LaborCost = 1037,
            Tax = 109.97m,
            Total = 2022.47m
        };
        private static List<Order> orders = new List<Order>
        {
            first,
            second,
            third
        };

        public List<Order> LoadOrders(string date)
        {
            if (date == "01012019")
            {
                return orders;
            }
            else
            {
                return null;
            }
        }

        public void SaveOrders(List<Order> saveOrders, string filePath)
        {
            foreach (Order o in saveOrders)
            {
                if (o.OrderNumber == first.OrderNumber)
                {
                    first = o;
                }
                if (o.OrderNumber == second.OrderNumber)
                {
                    second = o;
                }
                if (o.OrderNumber == third.OrderNumber)
                {
                    third = o;
                }
            }
            orders = saveOrders;
        }
    }
}
