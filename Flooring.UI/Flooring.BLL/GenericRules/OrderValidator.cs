using Flooring.Data.FlooringIO;
using Flooring.Models;
using Flooring.Models.Responses;
using Flooring.BLL.GetAreaRules;
using Flooring.BLL.GetNameRules;
using Flooring.BLL.GetProductRules;
using Flooring.BLL.GetTaxesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GenericRules
{
    public class OrderValidator
    {
        public SaveOrderResponse SaveOrder(Order order)
        {
            SaveOrderResponse finalResponse = new SaveOrderResponse();

            AddNameRule nameRule = new AddNameRule();
            GetNameResponse nameResponse = new GetNameResponse();

            nameResponse = nameRule.GetName(order.CustomerName);

            AddAreaRule areaRule = new AddAreaRule();
            GetAreaResponse areaResponse = new GetAreaResponse();

            areaResponse = areaRule.GetArea(order.Area.ToString());

            AddProductRule productRule = new AddProductRule();
            GetProductResponse productResponse = new GetProductResponse();

            productResponse = productRule.GetProduct(order.ProductType);

            AddTaxesRule taxesRule = new AddTaxesRule();
            GetTaxesResponse taxesResponse = new GetTaxesResponse();

            taxesResponse = taxesRule.GetTaxes(order.State);

            finalResponse.NameIsOkay = nameResponse.Success;
            finalResponse.AreaIsOkay = areaResponse.Success;
            finalResponse.ProductIsOkay = productResponse.Success;
            finalResponse.TaxIsOkay = taxesResponse.Success;

            if (finalResponse.NameIsOkay && finalResponse.AreaIsOkay && finalResponse.ProductIsOkay && finalResponse.TaxIsOkay)
            {
                finalResponse.EverythingIsAlright = true;
            }
            else
            {
                finalResponse.EverythingIsAlright = false;
            }

            return finalResponse;
        }
    }
}
