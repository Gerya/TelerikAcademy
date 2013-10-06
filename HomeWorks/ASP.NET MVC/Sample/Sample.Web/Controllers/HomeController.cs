using Sample.Model;
using Sample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = this.Data.GetRepository<Laptop>().All().OrderBy(l => l.Price).Take(6).Select(LaptopViewModel.FromLaptop);
            return View(model);
        }       
    }
}