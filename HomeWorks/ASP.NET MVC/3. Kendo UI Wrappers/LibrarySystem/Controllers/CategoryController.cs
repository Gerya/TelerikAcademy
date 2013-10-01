using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarySystem;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private LibrarySystemEntities db = new LibrarySystemEntities();


        public ActionResult Category_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetAllCategory().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        // GET: /Category/
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            return View(GetAllCategory());
        }

        private IQueryable<CategoryViewModel> GetAllCategory()
        {
            return db.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: /Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Category/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: /Category/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Category category = db.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(category);
        //}

        // POST: /Category/Delete/5
        [ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteAlabala(int id)
        {
            var booksToDelete = db.Books.Where(b => b.CategoryId == id);
            db.Books.RemoveRange(booksToDelete);

            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CategoryViewModel model)
        //{
        //    if (model != null)
        //    {
        //        var category = db.Categories.Find(model.Id);
        //        db.Categories.Remove(category);
        //        db.SaveChanges();
        //    }
        //    return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
