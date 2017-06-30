using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private OrderDao db = new OrderDao();

        // GET: Admin/Orders
        public ActionResult Index()
        {
            return View(db.list());
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(long id)
        {
            
            List<OrderDetail> list = db.detail(id);
            List<CartItem> re = new List<CartItem>();
            var product = new ProductDao();
            ViewBag.Product = product;
            foreach(var item in list)
            {
                CartItem ca = new CartItem();
                ca.Product = product.findByID(item.ProductID);
                ca.Quantity = (int)item.Quantity;
                re.Add(ca);

            }


            return View(re);
        }

        // GET: Admin/Orders/Create
     
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.findByID(id);
            order.Status = false;
            db.update(order);
            if (order == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

       
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.findByID(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            db.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.dispose();
            }
            base.Dispose(disposing);
        }
    }
}
