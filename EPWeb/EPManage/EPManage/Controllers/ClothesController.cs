using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPManageWeb.Models;
using EPManageWeb.Helper;

namespace EPManageWeb.Controllers
{
    public class ClothesController : BaseController
    {
        [CookiesAuthorize]
        public ActionResult SearchByNO(string no)
        {
            var clothes = DbContext.Clothes.Where(t => t.ProductNO.Contains(no) || t.SampleNO.Contains(no)).ToList().Select(t => new ClothesDetailModel(t)).ToList();
            return View(clothes);
        }

    }
}
