﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPManageWeb.Models;
using EPManageWeb.Helper;
using EPManageWeb.Entities.Models;

namespace EPManageWeb.Controllers
{
    public class ClothesController : BaseController
    {
        private const int PAGE_SIZE = 10;

        [CookiesAuthorize]
        public ActionResult SearchByNO(string no, int page = 1)
        {
            IEnumerable<Clothes> clothes = DbContext.Clothes;
            if (!String.IsNullOrEmpty(no)) clothes = clothes.Where(t => (t.ProductNO.Contains(no) || t.SampleNO.Contains(no)) && t.IsDeleted == false);
            int totalCount = clothes.Count();
            clothes = clothes.OrderByDescending(t => t.Id).Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            return View(clothes.ToPageList<Clothes>(page, PAGE_SIZE, totalCount));
        }

        [CookiesAuthorize]
        public ActionResult Search(SearchDocument doc)
        {
            List<Clothes> clothes = SaveClothesHelper.Search(doc);
            return View(clothes);
        }


        [HttpPost]
        public ActionResult Pics(int id, string type)
        {
            var clothes = DbContext.Clothes.SingleOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (clothes != null)
            {
                switch (type)
                {
                    case "clothes": return View(clothes.ClothesPicFiles());
                    case "modelversion": return View(clothes.ModelVersionPicFiles());
                    case "style": return View(clothes.StylePicFiles());
                    default: break;
                }
            }
            return View();
        }

        [HttpGet]
        [CookiesAuthorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        [CookiesAuthorize]
        public ActionResult Edit(int id)
        {
            var clothes = DbContext.Clothes.SingleOrDefault(t => t.Id == id && t.IsDeleted == false);
            return View(clothes);
        }

        [CookiesAuthorize]
        [HttpPost]
        public ActionResult Edit(Clothes model)
        {

            Clothes c = DbContext.Clothes.SingleOrDefault(t => t.Id == model.Id);
            if (c != null)
            {
                c.Comment = model.Comment;
                c.ProductedCount = model.ProductedCount;
                c.SaledCount = model.SaledCount;
                c.SampleNO = c.SampleNO;
                c.ProductNO = c.ProductNO;
                c.AssessoriesFile = model.AssessoriesFile ?? string.Empty;
                c.ClothesPics = model.ClothesPics ?? string.Empty;
                c.ClothesSize = model.ClothesSize ?? string.Empty;
                c.ModelVersionPics = model.ModelVersionPics ?? string.Empty;
                c.SampleFile = model.SampleFile ?? string.Empty;
                c.StylePics = model.StylePics ?? string.Empty;
                c.TechnologyFile = model.TechnologyFile ?? string.Empty;

                DbContext.OperationLogs.Add(new OperationLog()
                {
                    User = CurrentUser,
                    Clothes = c,
                    OperationType = OperationType.EditClothes.ToString()
                });

                DbContext.SaveChanges();
                SaveClothesHelper.RemoveDocument(c.Id);
                SaveClothesHelper.Save(c);
                return new ContentResult() { Content = "true" };
            }
            return new ContentResult() { Content = "false" };
        }

        [HttpGet]
        [CookiesAuthorize]
        public ActionResult Del(int id)
        {
            var clothes = DbContext.Clothes.SingleOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (clothes != null)
            {
                clothes.IsDeleted = true;
                SaveClothesHelper.RemoveDocument(id);
                DbContext.OperationLogs.Add(new OperationLog() { Clothes = clothes, User = CurrentUser, OperationType = OperationType.DelClothes.ToString() });
            }
            DbContext.SaveChanges();
            return new ContentResult() { Content = "true" };
        }

        [HttpGet]
        [CookiesAuthorize]
        public ActionResult Detail(int id)
        {
            var clothes = DbContext.Clothes.SingleOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (clothes != null)
            {
                ViewBag.CurrentClothesType = clothes.ClothesType;
                clothes.ViewCount = clothes.ViewCount + 1;
                DbContext.SaveChanges();
                return View(clothes);
            }
            else
                return new ContentResult() { Content = "未找到相应的记录" };
        }

        [HttpGet]
        [CookiesAuthorize]
        public ActionResult Download(int id, string type)
        {
            var clothes = DbContext.Clothes.SingleOrDefault(t => t.Id == id && t.IsDeleted == false);
            if (clothes == null || String.IsNullOrEmpty(type))
                return new HttpNotFoundResult();
            else
            {
                var log = new OperationLog() { Clothes = clothes, User = CurrentUser, OperationType = OperationType.DownLoadFile.ToString() };
                DbContext.OperationLogs.Add(log);
                DbContext.SaveChanges();

                var filePath = GetPathFile(clothes, type);
                if (String.IsNullOrEmpty(filePath) || filePath == "NOTFOUND") return new HttpNotFoundResult();

                if (filePath.LastIndexOf('.') > -1)
                {
                    var extenstion = filePath.Substring(filePath.LastIndexOf('.') + 1);
                    return new FilePathResult(Server.MapPath(filePath), "application/octet-strea") { FileDownloadName = String.Format("{0}{1}.{2}", clothes.SampleNO, GetDownloadFileName(type), extenstion) };
                }
                else
                {
                    return new FilePathResult(Server.MapPath(filePath), "application/octet-strea") { FileDownloadName = String.Format("{0}{1}", clothes.SampleNO, GetDownloadFileName(type)) };
                }
            }
        }

        private string GetPathFile(Clothes clothes, string type)
        {
            switch (type)
            {
                case "SampleFile": return clothes.SampleFile;
                case "TechnologyFile": return clothes.TechnologyFile;
                case "AssessoriesFile": return clothes.AssessoriesFile;
                default: return "NOTFOUND";
            }
        }

        private string GetDownloadFileName(string type)
        {
            switch (type)
            {
                case "SampleFile": return "示例文件";
                case "TechnologyFile": return "工艺单";
                case "AssessoriesFile": return "辅料卡";
                default: return "NOTFOUND";
            }
        }

    }
}