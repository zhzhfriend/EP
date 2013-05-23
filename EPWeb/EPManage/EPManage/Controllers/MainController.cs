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
            ClothesType clothesType = DbContext.ClothesTypes.SingleOrDefault(t => t.Id == id);
            if (clothesType == null)
                clothesType = DbContext.ClothesTypes.FirstOrDefault();

            if (clothesType.Children != null && clothesType.Children.Count > 0)
                clothesType = clothesType.Children[0];

            ViewBag.ClothesTypes = DbContext.ClothesTypes.Where(t => t.Parent == null).ToList();

            if (clothesType != null)
            {
                ViewBag.CurrentClothesType = clothesType;
                return View(clothesType);
            }
            return new HttpNotFoundResult();
        }

        [CookiesAuthorize]
        [HttpPost]
        public ActionResult Search(SearchDocument searchDocument)
        {
            List<Clothes> clothes = SaveClothesHelper.Search(searchDocument);
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
            if (!ValidClothesSize(model.ClothSize)) return new JsonResult() { Data = false };


            var pinglei = DbContext.ClothesParts.FirstOrDefault(t => t.Name == "品类" && t.ClothType.Id == model.ClothesTypeId);

            Clothes c = new Clothes()
            {
                Comment = model.Comment,
                ProductedCount = model.ProductedCount,
                SaledCount = model.SaledCount,
                SampleNO = model.SampleNO ?? string.Empty,
                ProductNO = model.ProductNO ?? string.Empty,
                AssessoriesFile = model.AccessoriesFile ?? string.Empty,
                ClothesPics = model.ClothesPics ?? string.Empty,
                ClothesSize = model.ClothSize ?? string.Empty,
                ModelVersionPics = model.ModelVersionPics ?? string.Empty,
                SampleFile = model.SampleFile ?? string.Empty,
                StylePics = model.StylePics ?? string.Empty,
                TechnologyFile = model.TechnologyFile ?? string.Empty,
                Tags = model.ClothesTags ?? string.Empty,
                ClothesType = DbContext.ClothesTypes.SingleOrDefault(t => t.Id == model.ClothesTypeId)
            };
            if (pinglei != null)
            {
                var tags = model.ClothesTags.Split(new char[] { ',' }).ToList();
                var pingleiType = pinglei.PartTypes.SingleOrDefault(t => tags.Contains(t.Name));
                if (pingleiType != null)
                    c.PingLei = pingleiType.Name;
            }

            DbContext.Clothes.Add(c);

            DbContext.OperationLogs.Add(new OperationLog()
           {
               User = CurrentUser,
               Clothes = c,
               OperationType = OperationType.AddClothes.ToString()
           });

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
        public ActionResult Edit(int id)
        {
            ClothesType clothesType = DbContext.ClothesTypes.Include("Children").Include("ClothesParts").Include("ClothesParts.Children").Include("ClothesParts.Children.PartTypes").Include("ClothesParts.Children.PartTypes.Children").Include("ClothesParts.PartTypes").Include("ClothesParts.PartTypes.Children").SingleOrDefault(t => t.Id == id);

            if (clothesType == null) return new HttpNotFoundResult();

            return View(clothesType);
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

        

        

        
        private bool ValidClothesSize(string size)
        {
            return true;
        }
    }
}
