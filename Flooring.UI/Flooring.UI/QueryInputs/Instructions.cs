using Flooring.BLL;
using Flooring.Data.FlooringIO;
using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.QueryInputs
{
    public class Instructions
    {
        public static void ListAvailableProducts()
        {
            IProductRepository repo = ProductRepositoryFactory.Create();
            List<Product> allProducts = repo.LoadProducts();

            int index = 1;

            Console.WriteLine("                            PRODUCT LIST");
            Console.WriteLine("____________________________________________________________________________");
            foreach (Product p in allProducts)
            {
                Console.WriteLine(index + " - " + p.ToString());
                index++;
            }
            Console.WriteLine("============================================================================");
        }

        public static void EditingInstructions()
        {
            Console.WriteLine("If input is empty, press enter to leave order value unchanged.");
        }
    }
}
