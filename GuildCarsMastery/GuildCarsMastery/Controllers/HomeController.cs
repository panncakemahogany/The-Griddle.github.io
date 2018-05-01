using GuildCarsMastery.BLL.Home;
using GuildCarsMastery.Data.Specials;
using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Domain.Business;
using GuildCarsMastery.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            HomeManager mgr = new HomeManager();

            HomeIndexVM model = new HomeIndexVM();

            var specialCourier = mgr.GetAllSpecials();
            var featuredCourier = mgr.GetFeaturedVehicles();

            if (specialCourier.Success)
                model.Specials = specialCourier.Package;
            else
                throw new Exception();
            if (featuredCourier.Success)
                model.FeaturedVehicles = featuredCourier.Package;
            else
                throw new Exception();

            return View(model);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            HomeManager mgr = new HomeManager();

            var specialCourier = mgr.GetAllSpecials();

            List<Special> model = new List<Special>();

            if (specialCourier.Success)
                model = specialCourier.Package;
            else
                throw new Exception();

            return View(model);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            HomeContactVM model = new HomeContactVM();

            return View(model);
        }

        //[HttpGet]
        //public ActionResult Contact(string vin)
        //{
        //    HomeContactVM model = new HomeContactVM();

        //    model.Message = vin;

        //    return View(model);
        //}

        [HttpPost]
        public ActionResult Contact(HomeContactVM model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
    }
}