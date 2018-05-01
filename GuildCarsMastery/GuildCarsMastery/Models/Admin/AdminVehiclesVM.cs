using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Parcels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models.Admin
{
    public class AdminVehiclesVM
    {
        public SearchQueryPackage Query { get; set; }
        public List<SelectListItem> YearRange { get; set; }
        public List<SelectListItem> PriceRange { get; set; }
        public Courier<List<Vehicle>> Result { get; set; }
    }
}