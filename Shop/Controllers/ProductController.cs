using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var product = new ProductDao();
            ViewBag.Product = product.list();
            return View();
        }
        [ChildActionOnly]
        public ActionResult Bar()
        {
           
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult SlideBar()
        {
            return PartialView();
        }
    }
}