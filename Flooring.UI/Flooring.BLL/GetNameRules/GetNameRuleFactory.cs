using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GetNameRules
{
    public class GetNameRuleFactory
    {
        public static IGetName Create(FunctionType type)
        {
            switch (type)
            {
                case FunctionType.AddOrder:
                    return new AddNameRule();
                case FunctionType.EditOrder:
                    return new EditNameRule();
                default:
                    throw new Exception("ERROR : VALUE NOT ENTERED PROPERLY IN FUNCTIONTYPE PARAMETER, DEVELOPER ISSUE");
            }
        }
    }
}
