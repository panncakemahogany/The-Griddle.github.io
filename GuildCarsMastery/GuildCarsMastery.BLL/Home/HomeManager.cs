using GuildCarsMastery.Data.Contacts;
using GuildCarsMastery.Data.Specials;
using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Domain.Business;
using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Parcels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.BLL.Home
{
    public class HomeManager
    {
        VehicleRepository vehicleRepo { get; set; }
        SpecialRepository specialRepo { get; set; }
        ContactRepository contactRepo { get; set; }

        public HomeManager()
        {
            vehicleRepo = new VehicleRepository();
            specialRepo = new SpecialRepository();
            contactRepo = new ContactRepository();
        }

        public Courier<List<Vehicle>> GetFeaturedVehicles()
        {
            Courier<List<Vehicle>> courier = new Courier<List<Vehicle>>();
            List<Vehicle> list = new List<Vehicle>();

            var inventory = vehicleRepo.GetInventory(InventoryType.Sales);

            foreach (var v in inventory)
            {
                if (v.Featured)
                {
                    list.Add(v);
                }
            }

            courier.Package = list;

            if (list != null &&
                list.Count > 0)
                courier.Success = true;
            else
            {
                courier.Success = false;
                courier.Message = "Unable to retrieve list of featured vehicles from database";
            }

            return courier;
        }

        public Courier<List<Special>> GetAllSpecials()
        {
            Courier<List<Special>> courier = new Courier<List<Special>>();

            courier.Package = specialRepo.GetSpecials();

            if (courier.Package != null &&
                courier.Package.Count > 0)
                courier.Success = true;
            else
            {
                courier.Success = false;
                courier.Message = "Unable to retrieve list of specials from database";
            }

            return courier;
        }

        public Courier<List<ContactUs>> GetAllContactSubmissions()
        {
            Courier<List<ContactUs>> courier = new Courier<List<ContactUs>>();

            courier.Package = contactRepo.GetAll();

            if (courier.Package != null &&
                courier.Package.Count > 0)
                courier.Success = true;
            else
            {
                courier.Success = false;
                courier.Message = "Unable to retrieve list of contact us submissions from database";
            }

            return courier;
        }

        public Courier<ContactUs> GetContactById(int id)
        {
            Courier<ContactUs> courier = new Courier<ContactUs>();

            courier.Package = contactRepo.GetById(id);

            if (courier.Package != null &&
                courier.Package.SubmissionId == id)
                courier.Success = true;
            else
            {
                courier.Success = false;
                courier.Message = "Unable to retrieve a contact us submission with that id";
            }

            return courier;
        }

        public Courier<ContactUs> AddContactSubmission(ContactUs submission)
        {
            Courier<ContactUs> courier = new Courier<ContactUs>();

            contactRepo.Add(submission);

            courier.Package = contactRepo.GetById(submission.SubmissionId);

            if (courier.Package.SubmissionId == submission.SubmissionId &&
                courier.Package.ContactName == submission.ContactName &&
                courier.Package.ContactEmail == submission.ContactEmail &&
                courier.Package.ContactPhone == submission.ContactPhone &&
                courier.Package.ContactMessage == submission.ContactMessage &&
                courier.Package.SubmissionDate == submission.SubmissionDate)
                courier.Success = true;
            else
            {
                courier.Success = false;
                courier.Message = "Unable to add contact us submission to database";
                courier.Package = submission;
            }

            return courier;
        }

        //public Courier<ContactUs> DeleteContactSubmission(int id)
        //{
        //    Courier<ContactUs> courier = GetContactById(id);
        //    List<ContactUs> goodState = new List<ContactUs>();
        //    ContactUs target = new ContactUs();
        //    target = courier.Package;

        //    goodState = contactRepo.GetAll();

        //    if (courier.Success)
        //    {
        //        contactRepo.Delete(id);

        //        if (goodState != contactRepo.GetAll() &&
        //            contactRepo.GetAll().Contains(target))
        //        {
        //            courier.Success = false;
        //            courier.Message = "Unable to remove contact us submission from database";
        //        }
        //        else
        //            courier.Success = true;

        //        return courier;
        //    }
        //    else
        //    {
        //        return courier;
        //    }
        //}
    }
}
