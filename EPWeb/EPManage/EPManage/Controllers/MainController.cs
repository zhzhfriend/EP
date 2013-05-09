using EPManageWeb.Helper;
using EPManageWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPManageWeb.Controllers
{
    public class MainController : Controller
    {
        [CookiesAuthorize]
        public ActionResult Index(int id)
        {
            return View();
        }

        [CookiesAuthorize]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [CookiesAuthorize]
        [HttpPost]
        public ActionResult Add(ClothesEditModel model)
        {
            return View();
        }

        [CookiesAuthorize]
        public ActionResult Statistic(int id)
        {
            return View();
        }
    }
}
