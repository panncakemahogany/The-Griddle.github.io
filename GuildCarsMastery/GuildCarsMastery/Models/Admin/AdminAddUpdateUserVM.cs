using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models.Admin
{
    public class AdminAddUpdateUserVM
    {
        public string TargetUserId { get; set; }
        [Required(ErrorMessage = "You must enter a first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter a last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must enter an email address")]
        public string Email { get; set; }
        public string RoleName { get; set; }
        [Required(ErrorMessage = "You must enter a password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "You must enter a matching password")]
        public string PasswordConfirmed { get; set; }

        public IEnumerable<SelectListItem> AvailableRoles { get; set; }
    }
}