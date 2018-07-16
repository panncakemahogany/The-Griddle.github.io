﻿using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GetTaxesRules
{
    public class GetTaxesRuleFactory
    {
        public static IGetTaxes Create(FunctionType type)
        {
            switch (type)
            {
                case FunctionType.AddOrder:
                    return new AddTaxesRule();
                case FunctionType.EditOrder:
                    return new EditTaxesRule();
                default:
                    throw new Exception("ERROR : VALUE NOT ENTERED PROPERLY IN FUNCTIONTYPE PARAMETER, DEVELOPER ISSUE");
            }
        }
    }
}