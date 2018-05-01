namespace GuildCarsMastery.Data.Migrations
{
    using GuildCarsMastery.Models.Users;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCarsMastery.Data.Account.AccountDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCarsMastery.Data.Account.AccountDbContext context)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));
            
            if (!roleMgr.RoleExists("Admin"))
            {
                roleMgr.Create(new AppRole() { Name = "Admin" });
            }
            if (!roleMgr.RoleExists("Sales"))
            {
                roleMgr.Create(new AppRole() { Name = "Sales" });
            }
            if (!roleMgr.RoleExists("Disabled"))
            {
                roleMgr.Create(new AppRole() { Name = "Disabled" });
            }
            
            var admin = new AppUser()
            {
                UserName = "test1",
                FirstName = "Addy",
                LastName = "McAdminson",
                Email = "addy@administration.com"
            };
            
            userMgr.Create(admin, "testing123");
            
            userMgr.AddToRole(admin.Id, "Admin");

            var sales = new AppUser()
            {
                UserName = "test2",
                FirstName = "Sally",
                LastName = "McSellerson",
                Email = "sallymcsellerson@sellingseashells.org"
            };

            userMgr.Create(sales, "testing123");

            userMgr.AddToRole(sales.Id, "Sales");

            var disabled = new AppUser()
            {
                UserName = "test3",
                FirstName = "Dizzy",
                LastName = "McFiredface",
                Email = "dizzy@doesntsell.org"
            };

            userMgr.Create(disabled, "testing123");

            userMgr.AddToRole(disabled.Id, "Disabled");
        }
    }
}
