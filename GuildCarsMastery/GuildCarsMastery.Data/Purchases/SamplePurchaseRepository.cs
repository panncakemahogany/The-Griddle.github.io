using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCarsMastery.Models.Domain.Business;

namespace GuildCarsMastery.Data.Purchases
{
    public class SamplePurchaseRepository
    {
        static List<Purchase> purchases = new List<Purchase>
        {
            new Purchase() { PurchaseId = 1, Username = "test2", VehicleId = 16, CustomerName = "Chump", CustomerPhone = "1111111111", CustomerEmail = "panncakemahogany@gmail.com", CustomerStreet1 = "227 East Mill St.", CustomerStreet2 = "", CustomerCity = "Owatonna", CustomerStateId = "MN", CustomerZipcode = "12345", PurchasePrice = 43000, PurchaseTypeId = PurchaseType.BankFinance },
            new Purchase() { PurchaseId = 2, Username = "test2", VehicleId = 17, CustomerName = "Dooooooood", CustomerPhone = "(222)222-2222", CustomerEmail = "mouthsodry@eyessored.com", CustomerStreet1 = "123 Happy Pl.", CustomerStreet2 = "Apt # 420", CustomerCity = "Peopleville", CustomerStateId = "CO", CustomerZipcode = "54321", PurchasePrice = 60000, PurchaseTypeId = PurchaseType.Cash },
            new Purchase() { PurchaseId = 3, Username = "test2", VehicleId = 18, CustomerName = "Billy", CustomerPhone = "333-333-3333", CustomerEmail = "emailaddress@believable.com", CustomerStreet1 = "454 Beaten Path", CustomerStreet2 = "#600", CustomerCity = "Citytown", CustomerStateId = "AR", CustomerZipcode = "23415", PurchasePrice = 49500, PurchaseTypeId = PurchaseType.DealerFinance }
        };

        public List<Purchase> GetAllPurchases()
        {
            return purchases;
        }
    }
}
