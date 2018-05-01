using GuildCarsMastery.BLL.Account;
using GuildCarsMastery.Models.Account;
using GuildCarsMastery.Models.Home;
using GuildCarsMastery.Models.Inventory;
using GuildCarsMastery.Models.Reports;
using GuildCarsMastery.Models.Sales;
using GuildCarsMastery.Models.Admin;
using GuildCarsMastery.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuildCarsMastery.Models.Domain.Vehicle;
using System.Web.Mvc;
using GuildCarsMastery.BLL.Admin;
using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models.Parcels.Account;

namespace GuildCarsMastery.Models
{
    public class IdentityPostmaster
    {
        public static Courier<AppUser> PackageChangePassword(AccountChangePasswordVM package)
        {
            IdentityManager mgr = new IdentityManager();

            UpdatePasswordParcel parcel = new UpdatePasswordParcel()
            {
                User = package.User,
                NewPassword = package.NewPassword
            };

            return mgr.ChangePassword(parcel);
        }

        public static Courier<AppUser> RetrieveUserByName(string userName)
        {
            IdentityManager mgr = new IdentityManager();

            return mgr.GetUserByUserName(userName);
        }

        public static Courier<AppUser> RetrieveUserById(string userId)
        {
            IdentityManager mgr = new IdentityManager();

            return mgr.GetUserById(userId);
        }

        public static Courier<AppUser> PackageUpdateUser(AdminAddUpdateUserVM model)
        {
            IdentityManager mgr = new IdentityManager();

            var courier = CleanAddUpdateVM(model);

            if (courier.Success)
            {
                return mgr.EditUser(courier.Package);
            }
            else
                return new Courier<AppUser>() { Success = false, Message = courier.Message };
        }

        public static Courier<AppUser> PackageNewUser(AdminAddUpdateUserVM model)
        {
            IdentityManager mgr = new IdentityManager();

            var courier = CleanAddUpdateVM(model);

            if (courier.Success)
            {
                return mgr.CreateNewUser(courier.Package);
            }
            else
                return new Courier<AppUser>() { Success = false, Message = courier.Message };
        }

        public static Courier<AddUpdateUserParcel> CleanAddUpdateVM(AdminAddUpdateUserVM model)
        {
            Courier<AddUpdateUserParcel> courier = new Courier<AddUpdateUserParcel>();

            if (model.FirstName != null &&
                model.LastName != null &&
                model.Email != null)
            {
                string userName = model.FirstName.Substring(0, 1) + model.LastName;
                bool hasNumber = false;
                int number = 0;
                for (int i = 0; i < model.Password.Length; i++)
                {
                    if (int.TryParse(model.Password.Substring(i, 1), out number))
                        hasNumber = true;
                    if (hasNumber)
                        break;
                }
                if (hasNumber && model.Password.Length > 6)
                {
                    courier.Success = true;
                    courier.Package = new AddUpdateUserParcel()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserName = userName,
                        Password = model.Password,
                        RoleName = model.RoleName
                    };

                    IdentityManager mgr = new IdentityManager();

                    var currentUser = mgr.GetUserById(model.TargetUserId);

                    courier.Package.Target = currentUser.Package;
                }
                else
                {
                    courier.Success = false;
                    courier.Message = "Password must be 7 or more character with letters and numbers";
                }
            }
            else
            {
                courier.Success = false;
                courier.Message = "Null values were entered";
            }

            return courier;
        }

        public static Courier<AppRole> GetUserRole(string userId)
        {
            IdentityManager mgr = new IdentityManager();

            var user = mgr.GetUserById(userId);

            return mgr.GetUserRole(user.Package);
        }

        public static List<SelectListItem> SetAvailableRoles()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            IdentityManager mgr = new IdentityManager();

            var roles = mgr.GetAllRoles();

            foreach (var r in roles.Package)
            {
                list.Add(new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name
                });
            }

            return list;
        }

        public static Courier<List<AppUser>> GetAllUsers()
        {
            IdentityManager mgr = new IdentityManager();

            return mgr.GetAllUsers();
        }

        public static Courier<List<AppRole>> GetAllRoles()
        {
            IdentityManager mgr = new IdentityManager();

            return mgr.GetAllRoles();
        }
    }
}