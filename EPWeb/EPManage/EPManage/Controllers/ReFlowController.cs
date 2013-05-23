﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPManageWeb.Helper;

namespace EPManageWeb.Controllers
{
    public class ReFlowController : BaseController
    {
        public ActionResult Index()
        {
            var clothes = DbContext.Clothes.ToList();
            SaveClothesHelper.RemovePreviousIndex();
            clothes.ForEach(c =>
                {
                    SaveClothesHelper.Save(c);
                });
            return new ContentResult() { Content = "Reflowed" };
        }

    }
}
