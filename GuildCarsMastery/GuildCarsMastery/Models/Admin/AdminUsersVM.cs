using GuildCarsMastery.Data.Account;
using GuildCarsMastery.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCarsMastery.Models.Admin
{
    public class AdminUsersVM
    {
        public List<AppUser> Users { get; set; }
        public List<AppRole> Roles { get; set; }
    }
}