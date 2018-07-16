using Flooring.BLL;
using Flooring.Data.FlooringIO;
using Flooring.Models;
using Flooring.Models.Responses;
using Flooring.UI.QueryInputs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            bool validInput = false;
            GetDateResponse dateResponse = null;

            while (!validInput)
            {
                string date = Query.GetDateFromUser();
                dateResponse = manager.FindOrdersOnDate(date, FunctionType.EditOrder);
                if (dateResponse.Success)
                {
                    validInput = true;
                }
                else
                {
                    Alert.AlertUserInvalidInput(dateResponse);
                }
            }

            if (dateResponse.FileExists)
            {
                List<Order> orders = manager.RetrieveOrdersOnDate(dateResponse);

                foreach (Order o in orders)
                {
                    GetProductResponse fillInProducts = manager.AssignProductInfo(o.ProductType, FunctionType.EditOrder);
                    GetTaxesResponse fillInTaxes = manager.AssignTaxInfo(o.State, FunctionType.EditOrder);

                    o.Product = fillInProducts.Product;
                    o.Taxes = fillInTaxes.Taxes;
                }

                GetOrderNumberResponse orderNumberResponse = null;

                bool validOrderNumber = false;
                int index = int.MinValue;

                while (!validOrderNumber)
                {
                    string orderNumber = Query.GetOrderNumberFromUser();
                    orderNumberResponse = manager.SelectOrderWithOrderNumber(orderNumber);
                    if (orderNumberResponse.Success)
                    {
                        if (orders.Exists(o => o.OrderNumber == orderNumberResponse.OrderNumber))
                        {
                            index = orders.FindIndex(o => o.OrderNumber == orderNumberResponse.OrderNumber);
                            validOrderNumber = true;
                        }
                        else
                        {
                            Alert.OrderNumberNotOnList(orderNumberResponse.OrderNumber);
                        }
                    }
                    else
                    {
                        Alert.AlertUserInvalidInput(orderNumberResponse);
                    }
                }

                QueryUserEditName(manager, orders, index);
                QueryUserEditTaxes(manager, orders, index);
                QueryUserEditProducts(manager, orders, index);
                QueryUserEditArea(manager, orders, index);

                bool confirmingSave = true;
                bool willSave = false;

                while (confirmingSave)
                {
                    Console.Clear();
                    orders[index].DynamicDisplayFormat();
                    willSave = Prompt.ConfirmChanges(2);
                    if (!willSave)
                    {
                        confirmingSave = Prompt.IsUserSure();
                    }
                    else
                    {
                        confirmingSave = false;
                    }
                }

                if (willSave)
                {
                    manager.SaveOrdersToFile(orders, dateResponse.FilePath);
                }
            }
        }

        public void QueryUserEditName(OrderManager manager, List<Order> orders, int index)
        {
            bool divider = false;
            orders[index].DynamicDisplayFormat();
            Instructions.EditingInstructions();
            Prompt.PressKeyToContinue();

            while (!divider)
            {
                string name = Query.GetNameFromUser();
                GetNameResponse nameResponse = new GetNameResponse();
                nameResponse = manager.AssignCustomerName(name, FunctionType.EditOrder);
                if (nameResponse.Success)
                {
                    if (nameResponse.Edited)
                    {
                        orders[index].CalculateOrderValues(nameResponse.Name, orders[index].Area, orders[index].Product, orders[index].Taxes);
                        divider = true;
                    }
                    else
                    {
                        divider = true;
                    }
                }
                else
                {
                    Alert.AlertUserInvalidInput(nameResponse);
                }
            }
        }

        public void QueryUserEditTaxes(OrderManager manager, List<Order> orders, int index)
        {
            bool divider = false;
            orders[index].DynamicDisplayFormat();
            Instructions.EditingInstructions();
            Prompt.PressKeyToContinue();

            while (!divider)
            {
                string state = Query.GetTaxesFromUser();
                GetTaxesResponse taxesResponse = new GetTaxesResponse();
                taxesResponse = manager.AssignTaxInfo(state, FunctionType.EditOrder);
                if (taxesResponse.Success)
                {
                    if (taxesResponse.Edited)
                    {
                        orders[index].CalculateOrderValues(orders[index].CustomerName, orders[index].Area, orders[index].Product, taxesResponse.Taxes);
                        divider = true;
                    }
                    else
                    {
                        divider = true;
                    }
                }
                else
                {
                    Alert.AlertUserInvalidInput(taxesResponse);
                }
            }
        }

        public void QueryUserEditProducts(OrderManager manager, List<Order> orders, int index)
        {
            bool divider = false;
            orders[index].DynamicDisplayFormat();
            Instructions.EditingInstructions();
            Prompt.PressKeyToContinue();

            while (!divider)
            {
                string product = Query.GetProductFromUser();
                GetProductResponse productResponse = new GetProductResponse();
                productResponse = manager.AssignProductInfo(product, FunctionType.EditOrder);
                if (productResponse.Success)
                {
                    if (productResponse.Edited)
                    {
                        orders[index].CalculateOrderValues(orders[index].CustomerName, orders[index].Area, productResponse.Product, orders[index].Taxes);
                        divider = true;
                    }
                    else
                    {
                        divider = true;
                    }
                }
                else
                {
                    Alert.AlertUserInvalidInput(productResponse);
                }
            }
        }

        public void QueryUserEditArea(OrderManager manager, List<Order> orders, int index)
        {
            bool divider = false;
            orders[index].DynamicDisplayFormat();
            Instructions.EditingInstructions();
            Prompt.PressKeyToContinue();

            while (!divider)
            {
                string area = Query.GetAreaFromUser();
                GetAreaResponse areaResponse = new GetAreaResponse();
                areaResponse = manager.AssignArea(area, FunctionType.EditOrder);
                if (areaResponse.Success)
                {
                    if (areaResponse.Edited)
                    {
                        orders[index].CalculateOrderValues(orders[index].CustomerName, areaResponse.Area, orders[index].Product, orders[index].Taxes);
                        divider = true;
                    }
                    else
                    {
                        divider = true;
                    }
                }
                else
                {
                    Alert.AlertUserInvalidInput(areaResponse);
                }
            }
        }
    }
}
