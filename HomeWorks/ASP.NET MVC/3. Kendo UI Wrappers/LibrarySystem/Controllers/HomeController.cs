using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        private LibrarySystemEntities context = new LibrarySystemEntities();

        public ActionResult Index()
        {
            var result = context.Categories.Include("Books").ToList().Select(x => new TreeViewItemModel
            {
                Text = x.Name,
                Items = x.Books.Select(y => new TreeViewItemModel
                {
                    Id = y.Id.ToString(),
                    Text = y.Title,
                    Url = "\\Home\\Details\\" + y.Id

                })
                    .ToList()
            });

            return View(result);
        }

        public ActionResult Details(int id)
        {
           var book =  context.Books.Find(id);

           return View(book);
        }

    }
}