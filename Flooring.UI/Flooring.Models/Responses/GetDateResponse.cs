using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class GetDateResponse : Response
    {
        public string Date { get; set; }
        public string FilePath { get; set; }
        public bool FileExists { get; set; }
    }
}
