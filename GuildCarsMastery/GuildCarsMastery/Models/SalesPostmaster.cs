using GuildCarsMastery.BLL.Inventory;
using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models
{
    public class SalesPostmaster
    {
        public static Courier<Vehicle> GetVehicleById(string id)
        {
            InventoryManager mgr = new InventoryManager();

            int number = int.MinValue;

            int.TryParse(id, out number);

            return mgr.GetById(number);
        }
        
        public static void ResetIndexVM(SalesInventoryVM model)
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

        public static void SetPurchaseFormDropdowns(SalesPurchaseVM model)
        {

        }
    }
}