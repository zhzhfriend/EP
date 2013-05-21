using EPManageWeb.Helper;
using EPManageWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPManageWeb.Entities.Models;

namespace EPManageWeb.Controllers
{
    public class MainController : BaseController
    {
        [CookiesAuthorize]
        public ActionResult Index(int id)
        {
            ClothesType clothesType = DbContext.ClothesTypes.Include("Children").Include("ClothesParts").Include("ClothesParts.Children").Include("ClothesParts.Children.PartTypes").Include("ClothesParts.PartTypes").SingleOrDefault(t => t.Id == id);
            if (clothesType == null)
                clothesType = DbContext.ClothesTypes.Include("Children").Include("ClothesParts").Include("ClothesParts.Children").Include("ClothesParts.Children.PartTypes").Include("ClothesParts.PartTypes").FirstOrDefault();

            ViewBag.ClothesTypes = DbContext.ClothesTypes.Where(t => t.Parent == null).ToList();

            if (clothesType != null)
                return View(clothesType);

            return new HttpNotFoundResult();
        }

        [CookiesAuthorize]
        [HttpPost]
        public ActionResult Search(string param)
        {
            List<ClothesDetailModel> clothes = SaveClothesHelper.Search(param).Select(t => new ClothesDetailModel(t)).ToList();
            return View(clothes);
        }

        [CookiesAuthorize]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [CookiesAuthorize]
        [HttpPost]
        public ActionResult Add(ClothesEditModel model)
        {
            Clothes c = new Clothes()
            {
                Comment = model.Comment,
                ProductedCount = model.ProductedCount,
                SaledCount = model.SaledCount,
                SampleNO = model.SampleNO,
                ProductNO = model.ProductNO,
                AssessoriesFile = model.AccessoriesFile,
                ClothesPics = model.ClothesPics,
                ClothesSize = model.ClothSize,
                ModelVersionPics = model.ModelVersionPics,
                SampleFile = model.SampleFile,
                StylePics = model.StylePics,
                TechnologyFile = model.TechnologyFile,
                Tags = model.ClothesTags
            };
            DbContext.Clothes.Add(c);
            DbContext.SaveChanges();
            SaveClothesHelper.Save(c);
            return new JsonResult() { Data = true };
        }

        [CookiesAuthorize]
        public ActionResult Statistic(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ClothesType clothesType = DbContext.ClothesTypes.Include("Children").Include("ClothesParts").Include("ClothesParts.Children").Include("ClothesParts.Children.PartTypes").Include("ClothesParts.Children.PartTypes.Children").Include("ClothesParts.PartTypes").Include("ClothesParts.PartTypes.Children").SingleOrDefault(t => t.Id == id);

            if (clothesType == null) return new HttpNotFoundResult();

            return View(clothesType);
        }

        [HttpGet]
        [CookiesAuthorize]
        public ActionResult Detail(int id)
        {
            var clothes = DbContext.Clothes.SingleOrDefault(t => t.Id == id);
            if (clothes != null)
            {
                clothes.ViewCount = clothes.ViewCount + 1;
                DbContext.SaveChanges();
                return View(new ClothesDetailModel(clothes));
            }
            else
                return new ContentResult() { Content = "未找到相应的记录" };
        }

        [HttpPost]
        [CookiesAuthorize]
        public ActionResult AddClothesPartType(string name, int partId)
        {
            var clothes = DbContext.ClothesParts.Include("PartTypes").SingleOrDefault(t => t.Id == partId);
            var type = new ClothesPartType() { Name = name, Order = clothes.PartTypes.Count };
            clothes.PartTypes.Add(type);
            DbContext.SaveChanges();
            return new JsonResult() { Data = new ClothesPartType() { Id = type.Id, Name = name } };
        }

        [HttpPost]
        [CookiesAuthorize]
        public ActionResult DeleteClothesPartType(int id)
        {
            var clothPartType = DbContext.ClothesPartTypes.SingleOrDefault(t => t.Id == id);
            if (clothPartType != null)
            {
                DbContext.ClothesPartTypes.Remove(clothPartType);
                DbContext.SaveChanges();
                return new JsonResult() { Data = true };
            }
            return new JsonResult() { Data = false };
        }

        [HttpPost]
        [CookiesAuthorize]
        public ActionResult Order(int partId, string items)
        {
            var itemsIds = items.Split(new char[] { ',' }).Where(t => !String.IsNullOrEmpty(t)).Select(t => int.Parse(t)).ToList();
            var clothPart = DbContext.ClothesParts.Include("PartTypes").SingleOrDefault(t => t.Id == partId);
            for (int i = 0; i < itemsIds.Count; i++)
            {
                clothPart.PartTypes.Single(t => t.Id == itemsIds[i]).Order = i;
            }
            DbContext.SaveChanges();
            return new JsonResult() { Data = true };
        }

        [HttpGet]
        [CookiesAuthorize]
        public ActionResult Download(int id, string type)
        {
            var clothes = DbContext.Clothes.SingleOrDefault(t => t.Id == id);
            if (clothes == null || String.IsNullOrEmpty(type))
                return new HttpNotFoundResult();
            else
            {
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
