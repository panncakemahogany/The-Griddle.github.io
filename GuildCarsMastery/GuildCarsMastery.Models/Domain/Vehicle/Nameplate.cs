using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Domain.Vehicle
{
    public class Nameplate
    {
        public string VehicleDescriptorSection { get; set; }
        public int NameplateId { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string NameplateMarque { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public DateTime DateAdded { get; set; }
        public string Username { get; set; }
    }
}
