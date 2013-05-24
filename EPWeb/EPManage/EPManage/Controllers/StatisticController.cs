﻿using System;
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
        private const int PAGE_SIZE = 5;

        public StatisticController()
        {
            List<ClothesPartType> pingleis = new List<ClothesPartType>();
            DbContext.ClothesParts.Where(t => t.Name == "品类").ToList().ForEach(t =>
            {
                pingleis.AddRange(t.PartTypes);
            });

            ViewBag.Pingleis = pingleis;
        }

        [CookiesAuthorize]
        public ActionResult Index(string type, string no, int page = 1)
        {
            IEnumerable<Clothes> clothes = DbContext.Clothes;
            if (!String.IsNullOrEmpty(no))
                clothes = DbContext.Clothes.Where(t => t.ProductNO.Contains(no) || t.SampleNO.Contains(no));

            if (!String.IsNullOrEmpty(type)) clothes = clothes.Where(t => t.PingLei == type);

            int totalCount = clothes.Count();
            clothes = clothes.OrderByDescending(t => t.Id).Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            return View(clothes.ToPageList<Clothes>(page, PAGE_SIZE, totalCount));
        }

        [CookiesAuthorize]
        public ActionResult Pinglei()
        {
            List<IGrouping<string, Clothes>> pinglei = DbContext.Clothes.GroupBy(t => t.PingLei).ToList();
            return View(pinglei);

        }
    }
}
