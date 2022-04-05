using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithJson.Models
{
    class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
