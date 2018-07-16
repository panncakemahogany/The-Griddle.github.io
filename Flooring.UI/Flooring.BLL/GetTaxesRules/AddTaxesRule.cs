using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using Flooring.Models;
using Flooring.Data.FlooringIO;

namespace Flooring.BLL.GetTaxesRules
{
    public class AddTaxesRule : IGetTaxes
    {
        public GetTaxesResponse GetTaxes(string state)
        {
            GetTaxesResponse response = new GetTaxesResponse();
            response.Success = false;

            ITaxesRepository repo = TaxesRepositoryFactory.Create();
            List<Taxes> allTaxes = repo.LoadTaxes();

            foreach (Taxes tax in allTaxes)
            {
                if (state.Equals(tax.StateAbbreviation, StringComparison.CurrentCultureIgnoreCase))
                {
                    response.Success = true;
                    response.Taxes = tax;
                }
                else if (state.Equals(tax.StateName, StringComparison.CurrentCultureIgnoreCase))
                {
                    response.Success = true;
                    response.Taxes = tax;
                }
            }

            if (!response.Success)
            {
                response.Message = $"{state} is either not a state we sell in OR not a valid state input";
            }

            return response;
        }
    }
}
