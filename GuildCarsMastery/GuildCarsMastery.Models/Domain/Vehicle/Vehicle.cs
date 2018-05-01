using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Domain.Vehicle
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int NameplateId { get; set; }
        public Nameplate Model { get; set; }
        public int Mileage { get; set; }
        public bool Transmission { get; set; }
        public int ProductionYear { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public ExteriorColor ExteriorColor { get; set; }
        public InteriorColor InteriorColor { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public bool Featured { get; set; }
    }
}
