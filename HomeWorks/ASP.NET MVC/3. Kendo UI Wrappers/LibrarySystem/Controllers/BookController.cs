using Kendo.Mvc.UI;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Data.Entity;

namespace LibrarySystem.Controllers
{
    public class BookController : Controller
    {
        private LibrarySystemEntities db = new LibrarySystemEntities();
        //
        // GET: /Book/
        public ActionResult Index()
        {
            PopulateCategories();
            return View(GetAllBooks());
        }

        public JsonResult GetCategory()
        {
            return Json(PopulateCategories(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetAllBooks().ToDataSourceResult(request));
        }

        public ActionResult CreateForm([DataSourceRequest] DataSourceRequest request)
        {
            return PartialView("_BookCreate");
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,
            BookViewModel product)
        {
            if (product != null && ModelState.IsValid)
            {
                var target = db.Books.Find(product.Id);
                var category = db.Categories.Find(product.Category.Id);
                if (target != null)
                {
                    target.Author = product.Author;
                    target.Description = product.Description;
                    target.Id = product.Id;
                    target.ISBN = product.ISBN;
                    target.Title = product.Title;
                    target.WebSite = product.WebSite;
                    target.Category = category;
                }
                db.SaveChanges();
            }

            return Json(new[]{product}.ToDataSourceResult(request, ModelState));
        }
        private IQueryable<BookViewModel> GetAllBooks()
        {
            return db.Books.Include(b => b.Category).Select(BookViewModel.FromBook);
        }


        public ActionResult Create(BookViewModel model, int Category)
        {
            if (model != null)
            {
                var selectedCategory = db.Categories.Find(Category);
                var newBook = new Book();
                newBook.Author = model.Author;
                newBook.Description = model.Description;
                newBook.ISBN = model.ISBN;
                newBook.Title = model.Title;
                newBook.WebSite = model.WebSite;
                newBook.Category = selectedCategory;
                db.Books.Add(newBook);
                db.SaveChanges();
            }
            return Content("");
        }

        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var bookToDelete = db.Books.Find(id);
            if (bookToDelete != null)
            {
                db.Books.Remove(bookToDelete);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private IQueryable<CategoryViewModel> PopulateCategories()
        {
            var categories = db.Categories
                        .Select(c => new CategoryViewModel
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                        .OrderBy(e => e.Name);
            ViewData["categories"] = categories.ToList();
            ViewData["defaultCategory"] = categories.First();
            return categories;
        }
	}
}