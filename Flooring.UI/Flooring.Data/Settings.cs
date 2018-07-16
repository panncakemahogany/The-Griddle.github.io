using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class Settings
    {
        public const string StateTaxesFilePath = @"C:\Data\Flooring.IO\Taxes.txt";
        public const string ProductListFilePath = @"C:\Data\Flooring.IO\Products.txt";

        public static string GetOrderDateFilePath(string date)
        {
            string filePath = @"C:\Data\Flooring.IO\Orders_" + date + ".txt";
            return filePath;
        }
    }
}
