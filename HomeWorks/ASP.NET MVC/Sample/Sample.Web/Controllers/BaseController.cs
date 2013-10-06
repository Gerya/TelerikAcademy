using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using Sample.Data;

namespace Sample.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Data;

        public BaseController(IUnitOfWork data)
        {
            this.Data = data;
        }

        public BaseController()
            : this(new UnitOfWork())
        {
        }
    }
}