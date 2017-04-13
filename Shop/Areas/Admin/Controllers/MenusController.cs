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
    public class MenusController : Controller
    {
        MenuDao m = new MenuDao();


        // GET: Admin/Menus
        public ActionResult Index()
        {
            var v = m.list();

            return View(v);
        }

        // GET: Admin/Menus/Details/5
        // GET: Admin/Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Text,Link,DisplayOrder,Target,Status")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                m.insert(menu);
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Admin/Menus/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = m.findByID(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text,Link,DisplayOrder,Target,Status")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                m.update(menu);
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Admin/Menus/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = m.findByID(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            m.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m.dispose();
            }
            base.Dispose(disposing);
        }
    }
}
