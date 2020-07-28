using ShoppingCore.Applicatons.Dtos.Orders;
using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Infrastructure.Core
{
    public static  class EntityExtensions
    {
        public static void UpdateOrder(this Order order, OrderViewModel orderVm)
        {
            order.CustomerName = orderVm.CustomerName;
            order.CustomerAddress = orderVm.CustomerName;
            order.CustomerEmail = orderVm.CustomerName;
            order.CustomerMobile = orderVm.CustomerName;
            order.CustomerMessage = orderVm.CustomerName;
            order.PaymentMethod = orderVm.CustomerName;
            order.CreatedDate = DateTime.Now;
            order.CreatedBy = orderVm.CreatedBy;
            order.Status = orderVm.Status;
            order.CustomerId = orderVm.CustomerId;
        }
    }
}
