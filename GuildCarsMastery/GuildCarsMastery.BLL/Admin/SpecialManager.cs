using GuildCarsMastery.Data.Specials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.BLL.Admin
{
    public class SpecialManager
    {
        static SpecialRepository repo { get; set; }

        public SpecialManager()
        {
            repo = new SpecialRepository();
        }
    }
}
