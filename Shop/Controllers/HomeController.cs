using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            var product = new ProductDao();
            ViewBag.Product = product.listTopHot(8);

           
            return View();
        }
        [ChildActionOnly]
        public ActionResult MenuMain()
        {
            var model = new MenuDao().list();

            return PartialView(model);
        }
        

      
    }
}