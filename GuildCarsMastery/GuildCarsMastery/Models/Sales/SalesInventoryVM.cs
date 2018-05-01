using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Parcels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models.Sales
{
    public class SalesInventoryVM
    {
        public SearchQueryPackage Query { get; set; }
        public List<SelectListItem> YearRange { get; set; }
        public List<SelectListItem> PriceRange { get; set; }
        public Courier<List<Vehicle>> Result { get; set; }

        public SalesInventoryVM()
        {
            List<SelectListItem> yRange = new List<SelectListItem>();
            List<SelectListItem> pRange = new List<SelectListItem>();
            pRange.Add(new SelectListItem() { Value = "", Text = "No Min", Selected = true });
            yRange.Add(new SelectListItem() { Value = "", Text = "No Min", Selected = true });
            for (int i = 2000; i < 2020; i++)
            {
                yRange.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }
            for (int i = 5000; i < 500000; i += 5000)
            {
                pRange.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }
            YearRange = yRange;
            PriceRange = pRange;
        }

        public void ResetDropdown()
        {
            List<SelectListItem> yRange = new List<SelectListItem>();
            List<SelectListItem> pRange = new List<SelectListItem>();
            yRange.Add(new SelectListItem() { Value = "", Text = "No Min", Selected = true });
            pRange.Add(new SelectListItem() { Value = "", Text = "No Min", Selected = true });
            for (int i = 2000; i < 2020; i++)
            {
                yRange.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }
            for (int i = 5000; i < 500000; i += 5000)
            {
                pRange.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }
            YearRange = yRange;
            PriceRange = pRange;
        }
    }
}