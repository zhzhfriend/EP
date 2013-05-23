using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPManageWeb.Entities.Models;
using EPManageWeb.Helper;

namespace EPManageWeb.Controllers
{
    public class StatisticController : BaseController
    {
        [CookiesAuthorize]
        public ActionResult Index(int id)
        {
            var clothes = DbContext.Clothes.ToList();
            List<ClothesPartType> pingleis = new List<ClothesPartType>();
            DbContext.ClothesParts.Where(t => t.Name == "品类").ToList().ForEach(t =>
                {
                    pingleis.AddRange(t.PartTypes);
                });

            ViewBag.Pingleis = pingleis;
            return View(clothes);
        }

        [CookiesAuthorize]
        public ActionResult Type(String type)
        {
            List<ClothesPartType> clothesTypes = new List<ClothesPartType>();
            DbContext.ClothesParts.Where(t => t.Name == "品类").ToList().ForEach(t =>
            {
                clothesTypes.AddRange(t.PartTypes);
            });

            ViewBag.ClothesTypes = clothesTypes;

            var clothesType = DbContext.ClothesPartTypes.SingleOrDefault(t => t.Name == type);
            if (clothesType != null)
            {
                return View("Index",DbContext.Clothes.Where(t => t.PingLei == type).ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [CookiesAuthorize]
        public ActionResult Pinglei()
        {
            List<IGrouping<string, Clothes>> pinglei = DbContext.Clothes.GroupBy(t => t.PingLei).ToList();
            return View(pinglei);

        }
    }
}
