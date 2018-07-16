using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GenericRules
{
    public class OrderNumberGeneratorRule
    {
        public static GetOrderNumberResponse GenerateOrderNumber(List<Order> orders)
        {
            GetOrderNumberResponse response = new GetOrderNumberResponse();
            response.Success = true;

            int newOrderNumber = int.MinValue;

            if (orders == null || orders.Count == 0)
            {
                response.OrderNumber = 1;
                return response;
            }
            else
            {
                newOrderNumber = orders.Max(o => o.OrderNumber) + 1;

                foreach (Order o in orders)
                {
                    if (newOrderNumber <= o.OrderNumber)
                    {
                        response.Success = false;
                        response.Message = "ERROR : ORDER NUMBER GENERATOR FAILURE DETECTED, ORDER NOT SAVED, DEVELOPER ISSUE";
                    }
                }

                if (response.Success)
                {
                    response.OrderNumber = newOrderNumber;
                }
            }
            return response;
        }
    }
}
