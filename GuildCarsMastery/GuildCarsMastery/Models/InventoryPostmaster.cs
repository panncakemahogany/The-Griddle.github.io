using GuildCarsMastery.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models
{
    public class InventoryPostmaster
    {
        public static void ResetUsedVM(InventoryUsedVM model)
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
            model.YearRange = yRange;
            model.PriceRange = pRange;
        }

        public static void ResetNewVM(InventoryNewVM model)
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
            model.YearRange = yRange;
            model.PriceRange = pRange;
        }
    }
}