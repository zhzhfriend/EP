using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mock.Models.Entities;


namespace Mock.Controllers
{
    public class Cloth_ShowController : Controller
    {
        //
        // GET: /Cloth_Show/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Cloth model)
        {
            return View("Cloth_Show");
        }
    }
}
