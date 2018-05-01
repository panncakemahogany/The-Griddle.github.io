using GuildCarsMastery.Models.Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCarsMastery.Models.Admin
{
    public class AdminSpecialsVM
    {
        public string NewSpecialTitle { get; set; }
        public string NewSpecialDescription { get; set; }
        public List<Special> CurrentSpecials { get; set; }
    }
}