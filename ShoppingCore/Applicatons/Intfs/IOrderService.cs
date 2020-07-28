using ShoppingCore.Applicatons.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Intfs
{
    public interface IOrderService
    {
        Task<OrderResultDto> CreateOrder(string orderViewModel, string listcart);
    }
}
