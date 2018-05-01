using GuildCarsMastery.BLL.Inventory;
using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Inventory;
using GuildCarsMastery.Models.Parcels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        [HttpGet]
        public ActionResult New()
        {
            InventoryNewVM model = new InventoryNewVM();

            InventoryPostmaster.ResetNewVM(model);

            return View(new InventoryNewVM());
        }

        [HttpPost]
        public ActionResult New(InventoryNewVM model)
        {
            SearchManager searchMgr = new SearchManager();

            model.Query.InventoryType = InventoryType.New;

            model.Result = searchMgr.GetSearchResult(searchMgr.ParcelPackage(model.Query));

            InventoryPostmaster.ResetNewVM(model);

            return View(model);
        }

        [HttpGet]
        public ActionResult Used()
        {
            InventoryUsedVM model = new InventoryUsedVM();

            InventoryPostmaster.ResetUsedVM(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Used(InventoryUsedVM model)
        {
            SearchManager searchMgr = new SearchManager();

            model.Query.InventoryType = InventoryType.Used;

            model.Result = searchMgr.GetSearchResult(searchMgr.ParcelPackage(model.Query));

            InventoryPostmaster.ResetUsedVM(model);

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            int number = int.Parse(id);

            InventoryManager mgr = new InventoryManager();

            var courier = mgr.GetById(number);

            if (courier.Success)
                return View(courier.Package);
            else
                throw new Exception(courier.Message);
        }
    }
}