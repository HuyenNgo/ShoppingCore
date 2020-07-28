using Dapper;
using Newtonsoft.Json;
using ShoppingCore.Applicatons.Dtos.Orders;
using ShoppingCore.Applicatons.Intfs;
using ShoppingCore.Infrastructure.Core;
using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Impls
{
    public class OrderService : BaseApplication, IOrderService
    {
        public OrderService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<OrderResultDto> CreateOrder(string orderViewModel, string listcart)
        {
            var order = JsonConvert.DeserializeObject<OrderViewModel>(orderViewModel);

            var orderNew = new Order();
            orderNew.UpdateOrder(order);
            //var detail = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(listcart);
            string _commandText = "Orders_CreateOrder";
            OrderResultDto r = null;

            var p = new DynamicParameters();
            p.Add("@CustomerName", orderNew.CustomerName??default);
            p.Add("@CustomerAddress", orderNew.CustomerAddress ?? default);
            p.Add("@CustomerEmail", orderNew.CustomerEmail??default);
            p.Add("@CustomerMobile", orderNew.CustomerMobile ?? default);
            p.Add("@CustomerMessage", orderNew.CustomerMessage ?? default);
            p.Add("@PaymentMethod", orderNew.PaymentMethod ?? default);
            p.Add("@CreatedDate", orderNew.CreatedDate ?? default);
            p.Add("@CreatedBy", orderNew.CreatedBy ?? default);
            p.Add("@PaymentStatus", orderNew.PaymentStatus ?? default);
            p.Add("@Status", orderNew.Status);
            p.Add("@CustomerId", orderNew.CustomerId ?? default);
            p.Add("@JSON_OrderDetails", listcart??default);

            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      r = conn.Query<OrderResultDto>(_commandText, p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                  });
            return r;

        }
    }
}
