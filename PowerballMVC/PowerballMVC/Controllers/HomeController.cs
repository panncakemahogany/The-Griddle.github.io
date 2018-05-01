using PowerballMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerballMVC.Controllers
{
    public class HomeController : Controller
    {
        private static List<Ticket> tickets;

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GrabBalls()
        {
            Ticket model = new Ticket();

            return View(model);
        }

        [HttpPost]
        public ActionResult GrabBalls(Ticket model)
        {
            return View(model);
        }

        public ActionResult ShowBalls()
        {
            return View();
        }

        public ActionResult BestBalls()
        {
            return View();
        }
    }
}