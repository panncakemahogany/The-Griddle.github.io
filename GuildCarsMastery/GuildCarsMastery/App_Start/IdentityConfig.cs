using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuildCarsMastery.Data.Account;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace GuildCarsMastery.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new AccountDbContext());

            app.CreatePerOwinContext<UserManager<AppUser>>((options, context) =>
                new UserManager<AppUser>(
                    new UserStore<AppUser>(context.Get<AccountDbContext>())));

            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(
                    new RoleStore<AppRole>(context.Get<AccountDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}