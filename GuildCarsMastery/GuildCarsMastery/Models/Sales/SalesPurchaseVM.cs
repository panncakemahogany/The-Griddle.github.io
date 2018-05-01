using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models.Sales
{
    public class SalesPurchaseVM
    {
        public Vehicle Vehicle { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        public List<SelectListItem> AvailableStates { get; set; }
        public string Zipcode { get; set; }
        public string PurchasePrice { get; set; }
        public string PurchaseTypeId { get; set; }
        public List<SelectListItem> AvailablePurchaseTypes { get; set; }
    }
}