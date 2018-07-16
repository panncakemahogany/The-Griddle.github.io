using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;
using Flooring.Models;
using Flooring.Models.Responses;
using Flooring.UI.QueryInputs;

namespace Flooring.UI.Workflows
{
    public class DisplayOrdersWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            bool validInput = false;
            GetDateResponse response = null;

            while (!validInput)
            {
                string date = Query.GetDateFromUser();
                response = manager.FindOrdersOnDate(date, FunctionType.DisplayOrders);
                if (response.Success && !response.FileExists)
                {
                    validInput = true;
                    Alert.AlertUserInvalidInput(response);
                }
                else if (response.Success)
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

                foreach (Order order in ordersFromFile)
                {
                    order.DisplayOrdersFormat(response.Date);
                }

                Prompt.PressKeyToContinue();
            }
        }
    }
}
