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
        private ProductDao db = new ProductDao();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var product = new MenuDao();
            ViewBag.listMenu = product;
            return View(db.list());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.findByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()

        {
            var product = new MenuDao();
            ViewBag.listMenu = product.list();
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Image,Price,CategoriesID,InsertDate")] Product product)
        {
            var f = Request.Files["Image"];
            if (f != null && f.ContentLength > 0)
            {
                product.Image = f.FileName;
                //     + f.FileName.Substring(f.FileName.LastIndexOf("."));
                f.SaveAs(Server.MapPath("~/Assert/" + product.Image));
            }


                if (ModelState.IsValid)
            {
                db.insert(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            var pr = new MenuDao();
            ViewBag.listMenu = pr.list();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.findByID(id);
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
        public ActionResult Edit([Bind(Include = "ID,Name,Image,Price,CategoriesID,InsertDate")] Product product)
        {
            var f = Request.Files["Image"];
            if (f != null && f.ContentLength > 0)
            {
                product.Image = f.FileName;
                //     + f.FileName.Substring(f.FileName.LastIndexOf("."));
                f.SaveAs(Server.MapPath("~/Assert/" + product.Image));
            }
            if (ModelState.IsValid)
            {
                db.update(product);
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
            Product product = db.findByID(id);
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
            db.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.disponse();
            }
            base.Dispose(disposing);
        }
    }
}
