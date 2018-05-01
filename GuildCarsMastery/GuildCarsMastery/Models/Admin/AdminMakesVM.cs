using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models.Admin
{
    public class AdminMakesVM
    {
        [Required]
        public string NewMake { get; set; }
        public List<string> CurrentMakes { get; set; }
    }
}