using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsMastery.Models.Admin
{
    public class AdminAddUpdateVehicleVM
    {
        public List<SelectListItem> Makes { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<SelectListItem> Exteriors { get; set; }
        public List<SelectListItem> Interiors { get; set; }
        public List<SelectListItem> Transmissions { get; set; }
        public string VehicleId { get; set; }
        public string ManufacturerId { get; set; }
        public string NameplateId { get; set; }
        public string BodyColor { get; set; }
        public string InteriorColor { get; set; }
        public string ProductionYear { get; set; }
        public string SelectedTransmission { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public string MSRP { get; set; }
        public string SalePrice { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public bool Featured { get; set; }
    }
}