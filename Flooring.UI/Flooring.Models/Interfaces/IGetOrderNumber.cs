﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models.Responses;

namespace Flooring.Models.Interfaces
{
    public interface IGetOrderNumber
    {
        GetOrderNumberResponse GetOrderNumber(string orderNumber, List<Order> orders);
    }
}