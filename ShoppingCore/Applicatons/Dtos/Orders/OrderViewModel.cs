using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Dtos.Orders
{
    public class OrderViewModel
    {
        public int ID { set; get; }

        [MaxLength(256)]
        public string CustomerName { set; get; }

        [MaxLength(256)]
        public string CustomerAddress { set; get; }

        [MaxLength(256)]
        public string CustomerEmail { set; get; }

        [MaxLength(50)]
        public string CustomerMobile { set; get; }

        [MaxLength(256)]
        public string CustomerMessage { set; get; }

        [MaxLength(256)]
        public string PaymentMethod { set; get; }

        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string PaymentStatus { set; get; }
        public bool Status { set; get; }

        [MaxLength(128)]
        public string CustomerId { set; get; }

        public string JSON_Orders { set; get; }
    }
}
