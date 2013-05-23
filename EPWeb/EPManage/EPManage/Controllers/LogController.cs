using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPManageWeb.Helper;

namespace EPManageWeb.Controllers
{
    public class LogController : BaseController
    {
        [CookiesAuthorize]
        public ActionResult Index()
        {
            var logs = DbContext.OperationLogs.OrderByDescending(t => t.Id).Take(10).ToList();
            return View(logs);
        }

    }
}
