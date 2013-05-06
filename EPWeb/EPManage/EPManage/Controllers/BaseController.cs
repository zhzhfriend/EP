using EPManageWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPManageWeb.Controllers
{
    public abstract class BaseController : Controller
    {
        protected EPDataContext DbContext = new EPDataContext();
    }
}
