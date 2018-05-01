using GuildCarsMastery.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Parcels.Account
{
    public class UpdatePasswordParcel
    {
        public AppUser User { get; set; }
        public string NewPassword { get; set; }
    }
}
