using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sales()
        {
            ReportSalesVM model = new ReportSalesVM();

            return View();
        }

        public ActionResult Inventory()
        {
            ReportInventoryVM model = new ReportInventoryVM();

            return View();
        }
    }
}