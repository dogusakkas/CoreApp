using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager m2m = new Message2Manager(new EfMessage2Repository());
        
        public IActionResult InBox()
        {
            int id = 3;
            var values = m2m.GetInboxListByWriter(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var values = m2m.TGetById(id);
            return View(values);
        }
    }
}
