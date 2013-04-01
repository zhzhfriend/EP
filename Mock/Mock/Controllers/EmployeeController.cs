using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mock.Models.Entities;

namespace Mock.Controllers
{
    public class EmployeeController : BaseController
    {
        //
        // GET: /Employee/

        public ActionResult show()
        {
            var list = this.DataContext.user_infos;
            return View(list);
        }

        public ActionResult add()
        {
            user_info us=new user_info();
            //us.id=
            return View("show");
        }

    }
}
