using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mock.Models.Entities;
using Mock.Data;

namespace Mock.Controllers
{
    public class EmployeeController : BaseController
    {
        //
        // GET: /Employee/

        public ActionResult show()
        {
            var list = this.DataContext.Users;
            return View(list);
        }

        public ActionResult add()
        {
            User us=new User();
            //us.id=
            return View("show");
        }

    }
}
