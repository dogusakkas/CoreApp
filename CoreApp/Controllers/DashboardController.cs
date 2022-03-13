using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        WriterManager wm = new WriterManager(new EfWriterRepository());

        Context c = new Context();
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.tbc = c.Blogs.Count().ToString();
            ViewBag.wbc = c.Blogs.Where(x => x.WriterID == writerid).Count();
            ViewBag.cc = c.Categories.Count();
            return View();
        }
    }
}
