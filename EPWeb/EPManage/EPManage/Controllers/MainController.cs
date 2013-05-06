using EPManageWeb.Helper;
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
        public ActionResult Index()
        {
            return View();
        }

    }
}
