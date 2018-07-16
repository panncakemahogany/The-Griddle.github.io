using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GetDateRules
{
    public class GetDateRuleFactory
    {
        public static IGetDate Create(FunctionType type)
        {
            switch (type)
            {
                case FunctionType.AddOrder:
                    return new FileExistenceOptionalRule();
                default:
                    return new FileMustExistRule();
            }
        }
    }
}
