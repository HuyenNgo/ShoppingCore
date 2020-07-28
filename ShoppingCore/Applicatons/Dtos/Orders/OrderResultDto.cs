using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Dtos.Orders
{
    public class OrderResultDto
    {
        public bool Status { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
