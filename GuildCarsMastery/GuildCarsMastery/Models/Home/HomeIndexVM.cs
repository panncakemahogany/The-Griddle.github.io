using GuildCarsMastery.Models.Domain.Business;
using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCarsMastery.Models.Home
{
    public class HomeIndexVM
    {
        public List<Special> Specials { get; set; }
        public List<Vehicle> FeaturedVehicles { get; set; }
    }
}