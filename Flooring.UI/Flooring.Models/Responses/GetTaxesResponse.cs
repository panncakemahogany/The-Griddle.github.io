using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class GetTaxesResponse : Response
    {
        public Taxes Taxes { get; set; }
        public bool Edited { get; set; }
    }
}
