using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GetAreaRules
{
    public class GetAreaRuleFactory
    {
        public static IGetArea Create(FunctionType type)
        {
            switch (type)
            {
                case FunctionType.AddOrder:
                    return new AddAreaRule();
                case FunctionType.EditOrder:
                    return new EditAreaRule();
                default:
                    throw new Exception("ERROR : VALUE NOT ENTERED PROPERLY IN FUNCTIONTYPE PARAMETER, DEVELOPER ISSUE");
            }
        }
    }
}
