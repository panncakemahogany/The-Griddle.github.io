using GuildCarsMastery.BLL.Inventory;
using GuildCarsMastery.Data.Account;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Admin;
using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Parcels.Inventory;
using GuildCarsMastery.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Vehicles()
        {
            AdminVehiclesVM model = new AdminVehiclesVM();

            AdminPostmaster.ResetVehicleVM(model);

            return View(model);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult Vehicles(AdminVehiclesVM model)
        {
            SearchManager searchMgr = new SearchManager();

            model.Query.InventoryType = InventoryType.Admin;

            model.Result = searchMgr.GetSearchResult(searchMgr.ParcelPackage(model.Query));

            AdminPostmaster.ResetVehicleVM(model);

            return View(model);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult AddVehicle()
        {
            AdminAddUpdateVehicleVM model = new AdminAddUpdateVehicleVM();

            AdminPostmaster.SetAddUpdateViewModelDropdowns(model);

            return View(model);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult AddVehicle(AdminAddUpdateVehicleVM model)
        {
            var courier = AdminPostmaster.CreateNewVehicle(model);

            if (courier.Success)
                return RedirectToAction("Vehicles");
            else
                return View(model);
        }

        [HttpGet]
        public ActionResult EditVehicle(string id)
        {
            int number = int.MinValue;
            int.TryParse(id, out number);

            var editTarget = AdminPostmaster.GetEditTarget(number);
            if (editTarget.Success)
            {
                Vehicle target = editTarget.Package;

                AdminAddUpdateVehicleVM model = new AdminAddUpdateVehicleVM()
                {
                    VehicleId = target.VehicleId.ToString(),
                    ManufacturerId = target.Model.ManufacturerId.ToString(),
                    NameplateId = target.NameplateId.ToString(),
                    BodyColor = target.ExteriorColor.ToString(),
                    InteriorColor = target.InteriorColor.ToString(),
                    ProductionYear = target.ProductionYear.ToString(),
                    Mileage = target.Mileage.ToString(),
                    VIN = target.VIN,
                    MSRP = target.MSRP.ToString(),
                    SalePrice = target.SalePrice.ToString(),
                    Description = target.Description,
                    ImageFileName = target.ImageFileName,
                    Featured = target.Featured
                };

                if (target.Transmission)
                    model.SelectedTransmission = "Automatic";
                else
                    model.SelectedTransmission = "Manual";

                AdminPostmaster.SetAddUpdateViewModelDropdowns(model);

                foreach (var m in model.Makes)
                {
                    if (m.Value == model.ManufacturerId)
                    {
                        m.Selected = true;
                        break;
                    }
                }
                foreach (var n in model.Models)
                {
                    if (n.Value == model.NameplateId)
                    {
                        n.Selected = true;
                        break;
                    }
                }
                foreach (var e in model.Exteriors)
                {
                    if (e.Value == model.BodyColor)
                    {
                        e.Selected = true;
                        break;
                    }
                }
                foreach (var i in model.Interiors)
                {
                    if (i.Value == model.InteriorColor)
                    {
                        i.Selected = true;
                        break;
                    }
                }
                foreach (var t in model.Transmissions)
                {
                    if (t.Text == model.SelectedTransmission)
                    {
                        t.Selected = true;
                        break;
                    }
                }
                return View(model);
            }
            else
                throw new Exception(editTarget.Message);

            
        }

        [HttpPost]
        public ActionResult EditVehicle(AdminAddUpdateVehicleVM model)
        {
            var courier = AdminPostmaster.UpdateVehicle(model);

            if (courier.Success)
                return RedirectToAction("Vehicles");
            else
                return View(model);
        }

        public ActionResult Users()
        {
            AdminUsersVM model = new AdminUsersVM();

            var users = IdentityPostmaster.GetAllUsers();
            var roles = IdentityPostmaster.GetAllRoles();

            model.Users = users.Package;
            model.Roles = roles.Package;

            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            AdminAddUpdateUserVM model = new AdminAddUpdateUserVM();

            model.AvailableRoles = IdentityPostmaster.SetAvailableRoles();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(AdminAddUpdateUserVM model)
        {
            AccountDbContext context = new AccountDbContext();

            if (model.Password != model.PasswordConfirmed)
            {
                ModelState.AddModelError("PasswordConfirmed", "Your password and password confirmation did not match.");
            }
            if (ModelState.IsValid)
            {
                var courier = IdentityPostmaster.PackageNewUser(model);

                if (courier.Success)
                    return RedirectToAction("Users");
                else
                {
                    ModelState.AddModelError("TargetUserName", courier.Message);

                    return View(model);
                }

            }
            else
            {
                model.AvailableRoles = IdentityPostmaster.SetAvailableRoles();

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditUser(string userId)
        {
            AdminAddUpdateUserVM model = new AdminAddUpdateUserVM();

            var courier = IdentityPostmaster.RetrieveUserById(userId);

            model.TargetUserId = userId;
            model.FirstName = courier.Package.FirstName;
            model.LastName = courier.Package.LastName;
            model.Email = courier.Package.Email;
            model.AvailableRoles = IdentityPostmaster.SetAvailableRoles();
            model.RoleName = IdentityPostmaster.GetUserRole(userId).Package.Name;

            foreach (var t in model.AvailableRoles)
            {
                if (t.Text == model.RoleName &&
                    t.Value == model.RoleName)
                    t.Selected = true;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(AdminAddUpdateUserVM model)
        {
            model.AvailableRoles = IdentityPostmaster.SetAvailableRoles();

            if (model.Password != model.PasswordConfirmed)
            {
                ModelState.AddModelError("PasswordConfirmed", "Your password and password confirmation did not match.");
            }
            if (ModelState.IsValid)
            {
                var courier = IdentityPostmaster.PackageUpdateUser(model);

                if (courier.Success)
                    return RedirectToAction("Users");
                else
                {
                    ModelState.AddModelError("TargetUserName", courier.Message);

                    return View(model);
                }
            }
            else
            {
                return View("EditUser", model);
            }
        }

        [HttpGet]
        public ActionResult Makes()
        {
            AdminMakesVM model = new AdminMakesVM();

            var courier = AdminPostmaster.GetAllMakes();

            if (!courier.Success)
                throw new Exception(courier.Message);
            else
            {
                List<string> listOfRows = new List<string>();
                foreach (var m in courier.Package)
                {
                    string column = ReportsPostmaster.WrapColumnEntry(m.ManufacturerName);
                    column += ReportsPostmaster.WrapColumnEntry(m.DateAdded.ToShortDateString());
                    column += ReportsPostmaster.WrapColumnEntry(m.Username);
                    string row = ReportsPostmaster.WrapRowEntry(column);
                    listOfRows.Add(row);
                }
                model.CurrentMakes = listOfRows;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Makes(AdminMakesVM model)
        {
            var makeCourier = AdminPostmaster.GetAllMakes();

            if (!makeCourier.Success)
                throw new Exception(makeCourier.Message);
            else
            {
                foreach (var make in makeCourier.Package)
                {
                    if (model.NewMake.ToUpper() == make.ManufacturerName.ToUpper())
                    {
                        ModelState.AddModelError("NewMake", "You provided a make that already exists in the database");
                        break;
                    }
                }
                if (!ModelState.IsValid)
                    return View(model);
                else
                {
                    string username = "test1";

                    if (User.Identity.IsAuthenticated)
                        username = User.Identity.Name;

                    var courier = AdminPostmaster.CreateNewMake(model.NewMake, username);

                    if (courier.Success)
                    {
                        return RedirectToAction("Makes");
                    }
                    else
                    {
                        ModelState.AddModelError("NewMake", courier.Message);
                        return View(model);
                    }
                }
            }
        }

        public ActionResult Models()
        {
            return View();
        }

        public ActionResult Specials()
        {
            return View();
        }
    }
}