using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.Models.Domain.Business
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Username { get; set; }
        public int VehicleId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreet1 { get; set; }
        public string CustomerStreet2 { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerStateId { get; set; }
        public string CustomerZipcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public PurchaseType PurchaseTypeId { get; set; }
    }
}
