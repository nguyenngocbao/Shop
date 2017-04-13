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

namespace Shop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDao pro = new ProductDao();
        

        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(pro.list());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = pro.findByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Code,MetaTitle,Description,Image,Price,Quantity,CategoriesID,Detail,Warranty,TopHot,ViewCount")] Product product)
        {
            if (ModelState.IsValid)
            {
                pro.insert(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = pro.findByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Code,MetaTitle,Description,Image,Price,Quantity,CategoriesID,Detail,Warranty,TopHot,ViewCount")] Product product)
        {
            if (ModelState.IsValid)
            {
                pro.update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = pro.findByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            pro.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pro.disponse();
            }
            base.Dispose(disposing);
        }
    }
}
