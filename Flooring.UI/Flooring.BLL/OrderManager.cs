using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using Flooring.Data;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using Flooring.BLL.GetDateRules;
using Flooring.BLL.GenericRules;
using Flooring.BLL.GetNameRules;
using Flooring.BLL.GetTaxesRules;
using Flooring.BLL.GetAreaRules;
using Flooring.BLL.GetProductRules;

namespace Flooring.BLL
{
    public class OrderManager
    {
        public IOrderRepository OrderRepository { get; set; }

        public OrderManager(IOrderRepository repository)
        {
            OrderRepository = repository;
        }

        public List<Order> RetrieveOrdersOnDate(GetDateResponse response)
        {
            List<Order> orders = OrderRepository.LoadOrders(response.Date);

            return orders;
        }

        public void SaveOrdersToFile(List<Order> orders, string filePath)
        {
            SaveOrderResponse[] response = new SaveOrderResponse[orders.Count];

            OrderValidator validator = new OrderValidator();
            int iterator = 0;
            foreach (Order o in orders)
            {
                response[iterator] = validator.SaveOrder(o);
                iterator++;
            }

            bool justDandy = true;

            for (int i = 0; i < response.Length; i++)
            {
                if (response[i].EverythingIsAlright)
                {
                    continue;
                }
                else
                {
                    justDandy = false;
                }
            }

            if (justDandy)
            {
                OrderRepository.SaveOrders(orders, filePath);
            }
            else
            {
                throw new Exception("GOD HAS ABANDONED US, THE PROGRAM IS FOR NAUGHT, THE DEVIL HAS TAKEN HUMAN FORM");
            }
        }

        public GetDateResponse FindOrdersOnDate(string date, FunctionType type)
        {
            GetDateResponse response = new GetDateResponse();

            IGetDate getDate = GetDateRuleFactory.Create(type);
            response = getDate.GetDate(date);

            return response;
        }

        public GetOrderNumberResponse SelectOrderWithOrderNumber(string orderNumber)
        {
            GetOrderNumberResponse response = new GetOrderNumberResponse();

            response = OrderNumberParsesRule.GetOrderNumber(orderNumber);

            return response;
        }

        public GetNameResponse AssignCustomerName(string name, FunctionType type)
        {
            GetNameResponse response = new GetNameResponse();

            IGetName getName = GetNameRuleFactory.Create(type);
            response = getName.GetName(name);

            return response;
        }

        public GetTaxesResponse AssignTaxInfo(string state, FunctionType type)
        {
            GetTaxesResponse response = new GetTaxesResponse();

            IGetTaxes getTaxes = GetTaxesRuleFactory.Create(type);
            response = getTaxes.GetTaxes(state);

            return response;
        }

        public GetProductResponse AssignProductInfo(string product, FunctionType type)
        {
            GetProductResponse response = new GetProductResponse();

            IGetProduct getProduct = GetProductRuleFactory.Create(type);
            response = getProduct.GetProduct(product);

            return response;
        }

        public GetAreaResponse AssignArea(string area, FunctionType type)
        {
            GetAreaResponse response = new GetAreaResponse();

            IGetArea getArea = GetAreaRuleFactory.Create(type);
            response = getArea.GetArea(area);

            return response;
        }

        public GetOrderNumberResponse AssignOrderNumber(List<Order> orders)
        {
            GetOrderNumberResponse response = new GetOrderNumberResponse();

            response = OrderNumberGeneratorRule.GenerateOrderNumber(orders);

            return response;
        }
    }
}
