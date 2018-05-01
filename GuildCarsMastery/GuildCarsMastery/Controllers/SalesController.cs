using GuildCarsMastery.BLL.Inventory;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Parcels.Inventory;
using GuildCarsMastery.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        [HttpGet]
        public ActionResult Index()
        {
            SalesInventoryVM model = new SalesInventoryVM();

            SalesPostmaster.ResetIndexVM(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SalesInventoryVM model)
        {
            SearchManager searchMgr = new SearchManager();

            model.Query.InventoryType = InventoryType.Sales;

            model.Result = searchMgr.GetSearchResult(searchMgr.ParcelPackage(model.Query));

            SalesPostmaster.ResetIndexVM(model);

            return View(model);
        }

        public ActionResult Purchase(string id)
        {
            var courier = SalesPostmaster.GetVehicleById(id);

            if (courier.Success)
            {
                SalesPurchaseVM model = new SalesPurchaseVM();

                model.Vehicle = courier.Package;

                return View(model);
            }
            else
                throw new Exception(courier.Message);
        }
    }
}