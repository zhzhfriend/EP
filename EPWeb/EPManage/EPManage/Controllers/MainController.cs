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
            ClothesType clothesType = DbContext.ClothesTypes.Include("ClothesParts").Include("ClothesParts.PartTypes").SingleOrDefault(t => t.Id == id);
            if (clothesType == null)
                clothesType = DbContext.ClothesTypes.Include("ClothesParts").Include("ClothesParts.PartTypes").FirstOrDefault();

            if (clothesType != null)
                return View(clothesType);

            return new HttpNotFoundResult();
        }

        [CookiesAuthorize]
        [HttpPost]
        public ActionResult Search(string param)
        {
            //List<ClothesDetailModel> clothes = DbContext.Clothes.ToList().Select(t => new ClothesDetailModel(t)).ToList();
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
                StyleNO = model.StyleNO,
                AssessoriesFile = model.AccessoriesFile,
                ClothesPics = model.ClothesPics,
                ClothesSize = model.ClothSize,
                ModelVersionPics = model.ModelVersionPics,
                SampleFile = model.SampleFile,
                StylePics = model.StylePics,
                TechnologyFile = model.TechnologyFile
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
        [CookiesAuthorize]
        public ActionResult Detail(int id)
        {
            var clothes = DbContext.Clothes.SingleOrDefault(t => t.Id == id);
            if (clothes != null)
                return View(new ClothesDetailModel(clothes));
            else
                return new HttpNotFoundResult();
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
