using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GetProductRules
{
    public class GetProductRuleFactory
    {
        public static IGetProduct Create(FunctionType type)
        {
            switch (type)
            {
                case FunctionType.AddOrder:
                    return new AddProductRule();
                case FunctionType.EditOrder:
                    return new EditProductRule();
                default:
                    throw new Exception("ERROR : VALUE NOT ENTERED PROPERLY IN FUNCTIONTYPE PARAMETER, DEVELOPER ISSUE");
            }
        }
    }
}
