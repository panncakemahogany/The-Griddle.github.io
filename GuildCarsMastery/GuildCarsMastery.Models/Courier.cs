using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models
{
    public class Courier <T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Package { get; set; }
    }
}
