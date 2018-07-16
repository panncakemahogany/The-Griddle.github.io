using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class GetNameResponse : Response
    {
        public string Name { get; set; }
        public bool Edited { get; set; }
    }
}
