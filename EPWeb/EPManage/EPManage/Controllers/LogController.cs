using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPManageWeb.Controllers
{
    public class LogController : BaseController
    {
        public ActionResult Index()
        {
            var logs = DbContext.OperationLogs.OrderByDescending(t => t.Id).Take(10).ToList();
            return View(logs);
        }

    }
}
