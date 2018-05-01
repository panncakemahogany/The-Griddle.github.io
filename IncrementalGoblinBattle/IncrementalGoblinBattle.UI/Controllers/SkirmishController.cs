using IncrementalGoblinBattle.Models.Units;
using IncrementalGoblinBattle.UI.Models.Skirmish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IncrementalGoblinBattle.UI.Controllers
{
    public class SkirmishController : Controller
    {
        public ActionResult Commence()
        {
            SkirmishCommenceVM model = new SkirmishCommenceVM();

            List<Unit> fighters = new List<Unit>()
            {
                new Unit(10),
                new Unit(10)
            };

            model.Combatants = fighters;

            return View(model);
        }
    }
}