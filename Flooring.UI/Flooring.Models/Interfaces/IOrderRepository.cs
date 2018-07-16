using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(string date);
        void SaveOrders(List<Order> orders, string filePath);
    }
}
