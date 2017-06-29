using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace Shop.Models
{
    [Serializable]
    public class CartItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
        public decimal? tong()
        {
           return Product.Price* Quantity;
        }
    }
}