using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore
{


    public class CurrentCart
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string Manufacture { get; set; }
        public string Country { get; set; }
        public decimal Cost { get; set; }
    }
}