using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPManageWeb.Entities.Models;

namespace EPManageWeb.Controllers
{
    public class StatisticController : BaseController
    {
        public ActionResult Index(int id)
        {
            var clothes = DbContext.Clothes.ToList();
            List<ClothesPartType> clothesTypes = new List<ClothesPartType>();
            DbContext.ClothesParts.Where(t => t.Name == "品类").ToList().ForEach(t =>
                {
                    clothesTypes.AddRange(t.PartTypes);
                });

            ViewBag.ClothesTypes = clothesTypes;
            return View(clothes);
        }

        public ActionResult Type(String type)
        {
            var clothesType = DbContext.ClothesPartTypes.SingleOrDefault(t => t.Name == type);
            if (clothesType != null)
            {
                return View(DbContext.Clothes.Where(t => t.PingLei == type).ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Pinglei()
        {
            List<IGrouping<string, Clothes>> pinglei = DbContext.Clothes.GroupBy(t => t.PingLei).ToList();
            return View(pinglei);

        }
    }
}
