using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Taxes
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }

        public override string ToString()
        {
            return $"{StateAbbreviation},{StateName},{TaxRate}";
        }
    }
}
