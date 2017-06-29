using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Model.DAO;
using Model.EF;

using System.Web.Script.Serialization;

namespace Shop.Controllers
{
    public class CartController : Controller
    {

        private const string CartSession = "CartSession";

        // GET: Cart
        public ActionResult Index()
        {

            var cart = Session[CartSession];
            var list = new Cart();
            if (cart != null)
            {
                list = (Cart) cart;
            }
            return View(list);

        }
        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var ca = (Cart)cart;
                var list = (List<Models.CartItem>)ca.list;
                if (list.Exists(x => x.Product.ID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session

                ca.list = list;
                Session[CartSession] = ca;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                
                list.Add(item);
                //Gán vào session
                var ca = new Cart();
                ca.list = list;
                Session[CartSession] = ca;
            }
            return RedirectToAction("Index");
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var ca = (Cart)Session[CartSession];
            

            var sessionCart = (List<Models.CartItem>)ca.list;

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            ca.list = sessionCart;
            Session[CartSession] = ca;
            return Json(new
            {
                status = true
            });
        }


        public ActionResult Delete(long id)
        {
            var ca = (Cart)Session[CartSession];


            var sessionCart = (List<Models.CartItem>)ca.list;
            sessionCart.RemoveAll(x => x.Product.ID == id);
            ca.list = sessionCart;
            Session[CartSession] = ca;

          return  RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipMobile = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;

            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new Model.Dao.OrderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);

                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                }
                
            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }




    }
}