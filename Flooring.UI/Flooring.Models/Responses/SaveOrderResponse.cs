using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class SaveOrderResponse
    {
        public bool NameIsOkay { get; set; }
        public bool AreaIsOkay { get; set; }
        public bool ProductIsOkay { get; set; }
        public bool TaxIsOkay { get; set; }
        public bool EverythingIsAlright { get; set; }
    }
}
