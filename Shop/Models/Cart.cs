using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace Shop.Models
{
    [Serializable]
    public class Cart
    {
        public List<CartItem> list { set; get; }
        public Customer kh { set; get; }
        public decimal? TongDonHang()
        {
            decimal? result = 0;
            foreach(CartItem item in list)
            {
                decimal? a = item.Product.Price;
                result += item.Product.Price * item.Quantity;
            }
            return result;
        }
    }
}