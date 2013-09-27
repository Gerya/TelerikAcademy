using BookStore.Data;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/
        public ActionResult Index()
        {
            var context = new BookStoreDbContext();
            var books = context.Books.Include("Author").Include("Category").Select(BookViewModel.FromBook);
            return View(books);
        }
	}
}