using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.BLL.GenericRules;
using Flooring.Data.FlooringIO;
using Flooring.Models;
using Flooring.Models.Responses;
using NUnit.Framework;

namespace Flooring.Tests
{
    [TestFixture]
    public class OrderRulesTests
    {
        [Test]
        [TestCase("11/19/1994", false)]
        [TestCase("01/01/2019", true)]
        public void CanListOrders(string date, bool expected)
        {
            OrderManager manager = OrderManagerFactory.Create();
            TestOrderRepository testRepo = new TestOrderRepository();
            GetDateResponse response = manager.FindOrdersOnDate(date, FunctionType.DisplayOrders);
            List<Order> orders = manager.RetrieveOrdersOnDate(response);
            List<Order> control = testRepo.LoadOrders("01012019");
            bool actual = control.Equals(orders);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("01/01/2019", "corndog", false)]
        [TestCase("01/01/2019", "-1", false)]
        [TestCase("01/01/2019", "0", false)]
        [TestCase("01/01/2019", "1", true)]
        public void CanSelectOrderWithOrderNumber(string date, string orderNumber, bool expected)
        {
            OrderManager manager = OrderManagerFactory.Create();
            GetDateResponse response = manager.FindOrdersOnDate(date, FunctionType.DisplayOrders);
            List<Order> orders = manager.RetrieveOrdersOnDate(response);
            GetOrderNumberResponse number = manager.SelectOrderWithOrderNumber(orderNumber);
            bool actual = number.Success;
            foreach (Order o in orders)
            {
                if (number.OrderNumber == o.OrderNumber)
                {
                    actual = true;
                    break;
                }
                else continue;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("XX", false)]
        [TestCase("corndog", false)]
        [TestCase("0", false)]
        [TestCase("LU", true)]
        [TestCase("TheMoon", true)]
        public void CanOnlyAssignValidTaxInfo(string state, bool expected)
        {
            OrderManager manager = OrderManagerFactory.Create();
            GetTaxesResponse actual = manager.AssignTaxInfo(state, FunctionType.AddOrder);
            Assert.AreEqual(expected, actual.Success);
        }

        [Test]
        [TestCase("corndog", false)]
        [TestCase("0", false)]
        [TestCase("1", true)]
        [TestCase("Wood", true)]
        public void CanOnlyAssignValidProduct(string product, bool expected)
        {
            OrderManager manager = OrderManagerFactory.Create();
            GetProductResponse actual = manager.AssignProductInfo(product, FunctionType.AddOrder);
            Assert.AreEqual(expected, actual.Success);
        }

        [Test]
        [TestCase("11/19/1994", true)]
        [TestCase("01/01/2019", true)]
        public void CanOnlyAssignValidOrderNumbers(string date, bool expected)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order order = new Order();
            GetDateResponse response = manager.FindOrdersOnDate(date, FunctionType.DisplayOrders);
            List<Order> orders = manager.RetrieveOrdersOnDate(response);
            GetOrderNumberResponse number = manager.AssignOrderNumber(orders);
            order.OrderNumber = number.OrderNumber;
            bool actual = (order.OrderNumber == 1 && orders == null || order.OrderNumber == orders.Max(o => o.OrderNumber) + 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("", 150, "Wood", "LU", false)]
        [TestCase("Riley", -50, "Wood", "LU", false)]
        [TestCase("Riley", 150, "Unobtainium", "LU", false)]
        [TestCase("Riley", 150, "Wood", "Canada", false)]
        [TestCase("Riley", 150, "Wood", "LU", true)]
        public void CanOnlySaveValidOrders(string name, decimal area, string productType, string state, bool expected)
        {
            Order order = new Order();

            order.CustomerName = name;
            order.Area = area;
            order.ProductType = productType;
            order.State = state;

            OrderValidator validator = new OrderValidator();
            SaveOrderResponse actual = validator.SaveOrder(order);

            Assert.AreEqual(expected, actual.EverythingIsAlright);
        }
    }
}
