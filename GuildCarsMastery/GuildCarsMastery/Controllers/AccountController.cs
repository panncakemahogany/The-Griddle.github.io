using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Account;
using GuildCarsMastery.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new AccountLoginVM();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLoginVM model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.Username, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        //[Authorize( Roles = "Sales, Admin")]
        public ActionResult ChangePassword()
        {
            return View(new AccountChangePasswordVM());
        }

        [HttpPost]
        //[Authorize(Roles = "Sales, Admin")]
        public ActionResult ChangePassword(AccountChangePasswordVM model)
        {
            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Your password confirmation did not match the password you entered.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var user = IdentityPostmaster.RetrieveUserByName(User.Identity.Name);

                if (user.Success)
                    model.User = user.Package;
                else
                    throw new Exception(user.Message);

                var result = IdentityPostmaster.PackageChangePassword(model);

                if (result.Success)
                {
                    var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
                    var authManager = HttpContext.GetOwinContext().Authentication;

                    authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

                    var identity = userManager.CreateIdentity(result.Package, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(identity);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("NewPassword", result.Message);

                    return View(model);
                }
            }
        }
    }
}