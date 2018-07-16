using Flooring.BLL;
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
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            bool validInput = false;
            GetDateResponse response = null;

            while (!validInput)
            {
                string date = Query.GetDateFromUser();
                response = manager.FindOrdersOnDate(date, FunctionType.AddOrder);
                if (response.Success)
                {
                    validInput = true;
                }
                else
                {
                    Alert.AlertUserInvalidInput(response);
                }
            }

            if (response.FileExists)
            {
                List<Order> ordersFromFile = manager.RetrieveOrdersOnDate(response);

                Order order = CreateNewOrder();
                bool confirmingSave = true;
                bool willSave = false;

                while (confirmingSave)
                {
                    Console.Clear();
                    order.AddOrderFormat();
                    willSave = Prompt.ConfirmChanges(1);
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
                    GetOrderNumberResponse saveResponse = manager.AssignOrderNumber(ordersFromFile);

                    if (saveResponse.Success)
                    {
                        order.OrderNumber = saveResponse.OrderNumber;
                        ordersFromFile.Add(order);
                        manager.SaveOrdersToFile(ordersFromFile, response.FilePath);
                    }
                    else
                    {
                        Alert.AlertUserInvalidInput(saveResponse);
                    }
                }
            }
            else
            {
                List<Order> newOrderList = new List<Order>();

                Order order = CreateNewOrder();
                bool confirmingSave = true;
                bool willSave = false;

                while (confirmingSave)
                {
                    Console.Clear();
                    order.AddOrderFormat();
                    willSave = Prompt.ConfirmChanges(1);
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
                    var fs = File.Create(response.FilePath);
                    fs.Close();
                    order.OrderNumber = 1;
                    newOrderList.Add(order);
                    manager.SaveOrdersToFile(newOrderList, response.FilePath);
                }
            }
        }

        public Order CreateNewOrder()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order newOrder = new Order();

            bool validName = false;
            string finalName = null;

            while (!validName)
            {
                string name = Query.GetNameFromUser();
                GetNameResponse response = new GetNameResponse();
                response = manager.AssignCustomerName(name, FunctionType.AddOrder);
                if (response.Success)
                {
                    finalName = response.Name;
                    validName = true;
                }
                else
                {
                    Alert.AlertUserInvalidInput(response);
                }
            }

            bool validState = false;
            Taxes finalTaxes = null;

            while (!validState)
            {
                string state = Query.GetTaxesFromUser();
                GetTaxesResponse response = new GetTaxesResponse();
                response = manager.AssignTaxInfo(state, FunctionType.AddOrder);
                if (response.Success)
                {
                    finalTaxes = response.Taxes;
                    validState = true;
                }
                else
                {
                    Alert.AlertUserInvalidInput(response);
                }
            }

            bool validProduct = false;
            Product finalProduct = null;

            while (!validProduct)
            {
                string product = Query.GetProductFromUser();
                GetProductResponse response = new GetProductResponse();
                response = manager.AssignProductInfo(product, FunctionType.AddOrder);
                if (response.Success)
                {
                    finalProduct = response.Product;
                    validProduct = true;
                }
                else
                {
                    Alert.AlertUserInvalidInput(response);
                }
            }

            bool validArea = false;
            decimal finalArea = decimal.MinValue;

            while (!validArea)
            {
                string area = Query.GetAreaFromUser();
                GetAreaResponse response = new GetAreaResponse();
                response = manager.AssignArea(area, FunctionType.AddOrder);
                if (response.Success)
                {
                    finalArea = response.Area;
                    validArea = true;
                }
                else
                {
                    Alert.AlertUserInvalidInput(response);
                }
            }

            newOrder.CalculateOrderValues(finalName, finalArea, finalProduct, finalTaxes);

            return newOrder;
        }
    }
}
