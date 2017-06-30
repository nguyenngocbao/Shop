using Model.DAO;
using Model.EF;
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
      
        public ActionResult Index(long id,int page)
        {

            var product = new ProductDao();
            ViewBag.Product = product.list(id);
            ViewBag.ProductRe = product.list(id, page);


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