using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using Flooring.Models.Interfaces;
using System.IO;

namespace Flooring.Data.FlooringIO
{
    public class TaxesRepository : ITaxesRepository
    {
        public List<Taxes> LoadTaxes()
        {
            List<Taxes> allTaxes = new List<Taxes>();

            using (StreamReader reader = new StreamReader(Settings.StateTaxesFilePath))
            {
                reader.ReadLine();
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Taxes taxes = new Taxes();
                    string[] newTaxes = line.Split(',');

                    taxes.StateAbbreviation = newTaxes[0];
                    taxes.StateName = newTaxes[1];
                    taxes.TaxRate = decimal.Parse(newTaxes[2]);

                    allTaxes.Add(taxes);
                }
            }

            return allTaxes;
        }
    }
}
