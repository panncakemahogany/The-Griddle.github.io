using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Domain.Vehicle
{
    public class Manufacturer
    {
        public string WorldManufacturerId { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public DateTime DateAdded { get; set; }
        public string Username { get; set; }
    }
}
