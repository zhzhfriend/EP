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
    public class AnnounceController : BaseController
    {
        //
        // GET: /Announce/

        public ActionResult Release()
        {
            ICategoryService cServ = ServiceBuilde.BuildCategoryService();
           List<CategoryInfo> categories = cServ.GetAll();
           ViewData["Categories"] = new SelectList(categories, "ID", "Name");
           return View("Release");
        }

        public ActionResult DoRelease()
        {
            AnnounceInfo announce = new AnnounceInfo()
            {
                ID = 1,
                Title = Request.Form["Title"],
                Category = Int32.Parse(Request.Form["Category"]),
                Content = Request.Form["Content"],
            };

            var result = from id in this.DataContext.user_infos
                         select id;
            int evenNumCount = result.Count();
            user_info us = new user_info();
            us.id = evenNumCount + "1";
            us.name = Request.Form["Title"];
            us.dep = Request.Form["Content"];

            this.DataContext.user_infos.InsertOnSubmit(us);
            this.DataContext.SubmitChanges();

            IAnnounceService aServ = ServiceBuilde.BuildAnnounceService();
            aServ.Release(announce);

            ViewData["Announce"] = announce;
            return View("ReleaseSucceed");
        }

    }
}
