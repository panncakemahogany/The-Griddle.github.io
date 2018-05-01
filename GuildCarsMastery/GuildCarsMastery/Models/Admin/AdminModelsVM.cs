using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models.Admin
{
    public class AdminModelsVM
    {
        public string NewModelMarque { get; set; }
        public int NewModelBodyStyle { get; set; }
        public int NewModelManufacturerId { get; set; }
        public List<SelectListItem> AvailableMakes { get; set; }
        public List<Nameplate> CurrentModels { get; set; }
    }
}