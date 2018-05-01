using GuildCarsMastery.Data.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using GuildCarsMastery.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using GuildCarsMastery.Models.Users.IdentityPackages;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Parcels.Account;

namespace GuildCarsMastery.BLL.Account
{
    public class IdentityManager
    {
        private static AccountDbContext context;
        private static UserManager<AppUser> userMgr;
        private static RoleManager<AppRole> roleMgr;

        public IdentityManager()
        {
            context = new AccountDbContext();
            userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));
        }

        public Courier<AppUser> CreateNewUser(AddUpdateUserParcel parcel)
        {
            Courier<AppUser> courier = new Courier<AppUser>();

            var user = new AppUser()
            {
                FirstName = parcel.FirstName,
                LastName = parcel.LastName,
                Email = parcel.Email,
                UserName = parcel.UserName
            };

            userMgr.Create(user, parcel.Password);

            userMgr.AddToRole(user.Id, parcel.RoleName);

            courier.Package = userMgr.Find(user.UserName, parcel.Password);

            if (courier.Package != null &&
                courier.Package.UserName == parcel.UserName &&
                courier.Package.Email == parcel.Email &&
                courier.Package.FirstName == parcel.FirstName &&
                courier.Package.LastName == parcel.LastName)
            {
                courier.Success = true;
            }
            else
            {
                courier.Success = false;
                courier.Message = "There was an issue adding the user to the database.";
            }

            return courier;
        }

        public Courier<AppUser> EditUser(AddUpdateUserParcel parcel)
        {
            Courier<AppUser> courier = new Courier<AppUser>();

            var cursor = userMgr.FindById(parcel.Target.Id);
            cursor.FirstName = parcel.FirstName;
            cursor.LastName = parcel.LastName;
            cursor.Email = parcel.Email;
            cursor.UserName = parcel.UserName;
            cursor.PasswordHash = userMgr.PasswordHasher.HashPassword(parcel.Password);
            var roles = cursor.Roles;
            
            if (roles.Count == 1)
            {
                var role = roleMgr.FindById(roles.First().RoleId);

                userMgr.RemoveFromRole(cursor.Id, role.Name);
            }

            var result = userMgr.Update(cursor);

            userMgr.AddToRole(cursor.Id, parcel.RoleName);

            courier.Success = result.Succeeded;
            courier.Message = "";
            foreach (var e in result.Errors)
            {
                courier.Message += "ERROR : " + e + ". ";
            }
            courier.Package = cursor;

            return courier;
        }

        public Courier<List<AppUser>> GetAllUsers()
        {
            Courier<List<AppUser>> courier = new Courier<List<AppUser>>();

            courier.Package = context.Users.ToList();

            return courier;
        }

        public Courier<AppUser> GetUserById(string id)
        {
            Courier<AppUser> courier = new Courier<AppUser>();

            courier.Package = userMgr.FindById(id);

            if (courier.Package != null)
            {
                courier.Success = true;
            }
            else
            {
                courier.Success = false;
                courier.Message = "Unable to retrieve user with given id";
            }

            return courier;
        }

        public Courier<AppUser> GetUserByUserName(string userName)
        {
            Courier<AppUser> courier = new Courier<AppUser>();

            courier.Package = userMgr.FindByName(userName);

            if (courier.Package != null &&
                courier.Package.UserName == userName)
            {
                courier.Success = true;
            }
            else
            {
                courier.Success = false;
                courier.Message = "A User by that name does not exist in our database.";
            }

            return courier;
        }

        public Courier<List<AppRole>> GetAllRoles()
        {
            Courier<List<AppRole>> courier = new Courier<List<AppRole>>();

            courier.Package = roleMgr.Roles.ToList();

            if (courier.Package != null &&
                courier.Package.Count > 0)
            {
                courier.Success = true;
            }
            else
            {
                courier.Success = false;
                courier.Message = "Unable to retrieve list of roles from database";
            }

            return courier;
        }

        public Courier<AppUser> ChangePassword(UpdatePasswordParcel parcel)
        {
            if (parcel.User != null)
            {
                string firstName = parcel.User.FirstName;
                string lastName = parcel.User.LastName;
                string email = parcel.User.Email;
                string userName = parcel.User.UserName;
                string id = parcel.User.Id;
                string oldPasswordHash = parcel.User.PasswordHash;

                string newPasswordHash = userMgr.PasswordHasher.HashPassword(parcel.NewPassword);
                parcel.User.PasswordHash = newPasswordHash;

                userMgr.Update(parcel.User);

                Courier<AppUser> courier = new Courier<AppUser>()
                {
                    Package = userMgr.FindById(id)
                };

                if (courier.Package != null &&
                    courier.Package.FirstName == firstName &&
                    courier.Package.LastName == lastName &&
                    courier.Package.Email == email &&
                    courier.Package.UserName == userName &&
                    courier.Package.Id == id &&
                    courier.Package.PasswordHash != oldPasswordHash)
                    courier.Success = true;
                else
                {
                    courier.Success = false;
                    courier.Message = "User password not properly updated";
                }

                return courier;
            }
            else
            {
                return new Courier<AppUser>() { Success = false, Message = "No user was attached to parcel" };
            }
        }

        public Courier<AppRole> GetUserRole(AppUser user)
        {
            Courier<AppRole> courier = new Courier<AppRole>();

            string userRoleId = user.Roles.Single().RoleId;

            courier.Package = roleMgr.FindById(userRoleId);

            if (courier.Package != null &&
                userMgr.IsInRole(user.Id, courier.Package.Name))
            {
                courier.Success = true;
            }
            else
            {
                courier.Success = false;
                courier.Message = "Given user did not match with a role";
            }

            return courier;
        }
    }
}
