using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GuildCarsMastery.Models.Parcels.Inventory
{
    public class SearchQueryPackage
    {
        public string Keyword { get; set; }
        public string MinYear { get; set; }
        public string MaxYear { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public InventoryType InventoryType { get; set; }
    }
}
