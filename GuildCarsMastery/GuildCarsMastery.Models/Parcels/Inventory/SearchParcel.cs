using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Parcels.Inventory
{
    public class SearchParcel
    {
        public string Keyword { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        private int ParcelDirection { get; set; }
        public InventoryType InventoryType { get; set; }

        public SearchParcel()
        {
            ParcelDirection = 0;
        }

        public int GetParcelDirection()
        {
            return ParcelDirection;
        }

        public void HasPriceQuery()
        {
            ParcelDirection += 1;
        }
        public void HasYearQuery()
        {
            ParcelDirection += 10;
        }
        public void HasKeyword()
        {
            ParcelDirection += 100;
        }
    }
}
