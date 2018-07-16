using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using Flooring.Models;
using Flooring.Data.FlooringIO;

namespace Flooring.BLL.GetProductRules
{
    public class AddProductRule : IGetProduct
    {
        public GetProductResponse GetProduct(string productType)
        {
            GetProductResponse response = new GetProductResponse();
            response.Success = false;

            IProductRepository repo = ProductRepositoryFactory.Create();
            List<Product> allProducts = repo.LoadProducts();
            int index = int.MinValue;

            if (int.TryParse(productType, out index))
            {
                index -= 1;
                if (index < allProducts.Count && index >= 0)
                {
                    response.Success = true;
                    response.Product = allProducts[index];
                }
                else
                {
                    response.Message = "The number you've selected is not valid.";
                }
            }
            else
            {
                foreach (Product p in allProducts)
                {
                    if (productType == p.ProductType)
                    {
                        response.Success = true;
                        response.Product = p;
                    }
                }

                if (!response.Success)
                {
                    response.Message = $"{productType} is not a valid product.";
                }
            }

            return response;
        }
    }
}
