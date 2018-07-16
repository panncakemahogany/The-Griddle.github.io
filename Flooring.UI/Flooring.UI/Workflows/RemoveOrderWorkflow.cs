using Flooring.BLL;
using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Responses;
using Flooring.UI.QueryInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            bool validDate = false;
            GetDateResponse dateResponse = null;

            while (!validDate)
            {
                string date = Query.GetDateFromUser();
                dateResponse = manager.FindOrdersOnDate(date, FunctionType.RemoveOrder);
                if (dateResponse.Success)
                {
                    validDate = true;
                }
                else
                {
                    Alert.AlertUserInvalidInput(dateResponse);
                }
            }

            if (dateResponse.FileExists)
            {
                List<Order> orders = manager.RetrieveOrdersOnDate(dateResponse);
                GetOrderNumberResponse orderNumberResponse = null;

                bool validOrderNumber = false;
                Order order = null;

                while (!validOrderNumber)
                {
                    string orderNumber = Query.GetOrderNumberFromUser();
                    orderNumberResponse = manager.SelectOrderWithOrderNumber(orderNumber);
                    if (orderNumberResponse.Success)
                    {
                        foreach (Order o in orders)
                        {
                            if (o.OrderNumber == orderNumberResponse.OrderNumber)
                            {
                                order = o;
                                validOrderNumber = true;
                            }
                            else continue;
                        }
                        if (!validOrderNumber)
                        {
                            Alert.OrderNumberNotOnList(orderNumberResponse.OrderNumber);
                        }
                    }
                    else
                    {
                        Alert.AlertUserInvalidInput(orderNumberResponse);
                    }
                }

                bool confirmingRemove = true;

                while (confirmingRemove)
                {
                    Console.Clear();
                    order.DisplayOrdersFormat(dateResponse.Date);
                    if (Prompt.ConfirmChanges(3))
                    {
                        if (Prompt.IsUserSure())
                        {
                            orders.Remove(order);

                            manager.SaveOrdersToFile(orders, dateResponse.FilePath);

                            confirmingRemove = false;
                        }
                        else
                        {
                            confirmingRemove = false;
                        }
                    }
                    else
                    {
                        confirmingRemove = false;
                    }
                }
            }
        }
    }
}
