using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class GetProductResponse : Response
    {
        public Product Product { get; set; }
        public bool Edited { get; set; }
    }
}
