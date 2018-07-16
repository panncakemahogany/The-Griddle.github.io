using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GenericRules
{
    public class OrderNumberParsesRule
    {
        public static GetOrderNumberResponse GetOrderNumber(string orderNumber)
        {
            GetOrderNumberResponse response = new GetOrderNumberResponse();

            int number = int.MinValue;

            if (int.TryParse(orderNumber, out number))
            {
                if (number > 0)
                {
                    response.OrderNumber = number;
                    response.Success = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "That was not a valid order number.";
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "That was not a valid order number.";
                return response;
            }
        }
    }
}
