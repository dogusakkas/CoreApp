using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.tbc = c.Blogs.Count().ToString();
            ViewBag.wbc = c.Blogs.Where(x => x.WriterID == 1).Count().ToString();
            ViewBag.cc = c.Categories.Count().ToString();
            return View();
        }
    }
}
