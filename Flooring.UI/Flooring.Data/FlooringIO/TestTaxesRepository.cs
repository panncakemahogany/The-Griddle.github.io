using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using Flooring.Models.Interfaces;
using System.IO;

namespace Flooring.Data.FlooringIO
{
    public class TestTaxesRepository : ITaxesRepository
    {
        private static Taxes taxes1 = new Taxes
        {
            StateAbbreviation = "MN",
            StateName = "Minnesota",
            TaxRate = 14.50m
        };
        private static Taxes taxes2 = new Taxes
        {
            StateAbbreviation = "AR",
            StateName = "Arkansas",
            TaxRate = 0.01m
        };
        private static Taxes taxes3 = new Taxes
        {
            StateAbbreviation = "LU",
            StateName = "TheMoon",
            TaxRate = 100m
        };
        private static List<Taxes> taxes = new List<Taxes>
        {
            taxes1,
            taxes2,
            taxes3
        };

        public List<Taxes> LoadTaxes()
        {
            return taxes;
        }
    }
}
