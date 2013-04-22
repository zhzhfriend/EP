using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mock.Models;
using Mock.Models.Interfaces;
using Mock.Models.Entities;
using Mock.Data;

namespace Mock.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        //public ActionResult Index()
        //{
        //    ICategoryService cServ = ServiceBuilde.BuildCategoryService();
        //    ViewData["Categories"] = cServ.GetAll();
        //    return View("index");

        //}
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(UserloginModel model)
        {
            var user = model.UserName;
            var a = model.PassWord;

            var users=this.DataContext.Users.Where(t => t.IsDeleted == false).SingleOrDefault(t => t.Name == model.UserName && t.PassWord == model.PassWord);
            if (user != null)
            {
                return View("Cloth");
            }
            return RedirectToAction("Index");
        }
    }
}
