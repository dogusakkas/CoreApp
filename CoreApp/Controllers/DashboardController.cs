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
            var name = User.Identity.Name;
            var namesurname = c.Users.Where(x => x.UserName == name).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.v = name;
            var writerID = c.Writers.Where(x => x.WriterMail == name).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterByID(writerID);

            ViewBag.tbc = c.Blogs.Count().ToString();
            ViewBag.wbc = c.Blogs.Where(x => x.WriterID == 1).Count().ToString();
            ViewBag.cc = c.Categories.Count().ToString();
            return View(values);
        }
    }
}
