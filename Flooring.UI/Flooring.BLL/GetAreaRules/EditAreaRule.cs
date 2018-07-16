using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GetAreaRules
{
    public class EditAreaRule : IGetArea
    {
        public GetAreaResponse GetArea(string area)
        {
            GetAreaResponse response = new GetAreaResponse();

            decimal areaChecker = decimal.MinValue;

            if (area.Length == 0)
            {
                response.Success = true;
                response.Edited = false;
                return response;
            }

            if (decimal.TryParse(area, out areaChecker))
            {
                if (areaChecker > 100M)
                {
                    response.Success = true;
                    response.Edited = true;
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
