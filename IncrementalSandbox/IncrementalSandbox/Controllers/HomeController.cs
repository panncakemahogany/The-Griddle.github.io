using IncrementalSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IncrementalSandbox.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JsMvcFusion()
        {
            JsMvcFusionVM model = new JsMvcFusionVM()
            {
                Clicks = 0,
                ClickMultiplier = 1,
                AutoClickers = 0
            };

            return View(model);
        }
    }
}