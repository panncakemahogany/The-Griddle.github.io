using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models.Responses;

namespace Flooring.Models.Interfaces
{
    public interface IGetTaxes
    {
        GetTaxesResponse GetTaxes(string state);
    }
}
