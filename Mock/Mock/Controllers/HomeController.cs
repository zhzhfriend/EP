using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mock.Models;
using Mock.Models.Interfaces;
using Mock.Models.Entities;

namespace Mock.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(UserloginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "admin" && model.PassWord == "1")
                    return View("Cloth_Show");
                else
                    ModelState.AddModelError("Error", "Invalid UserName/Password");
            }
            else
            {
                ModelState.AddModelError("Error", "UserName/Password Can't be Empty");
            }
            return View(model);
        }
    }
}
