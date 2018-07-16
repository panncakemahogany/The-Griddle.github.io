using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;

namespace Flooring.BLL.GetAreaRules
{
    public class AddAreaRule : IGetArea
    {
        public GetAreaResponse GetArea(string area)
        {
            GetAreaResponse response = new GetAreaResponse();

            decimal areaChecker = decimal.MinValue;

            if (decimal.TryParse(area, out areaChecker))
            {
                if (areaChecker > 100M)
                {
                    response.Success = true;
                    response.Area = areaChecker;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "The area for an order must be greater than 100 square feet.";
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "That was not a valid value for area.";
                return response;
            }
        }
    }
}
