using EPManageWeb.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPManageWeb.Models
{
    public class ClothesEditModel
    {
        [Display(Name = "样板编号")]
        public String SampleNO { get; set; }
        [Display(Name = "大货编号")]
        public String ProductNO { get; set; }

        [Display(Name = "款式图")]
        public String StylePics { get; set; }
        [Display(Name = "成衣图片")]
        public String ClothesPics { get; set; }
        [Display(Name = "版型图")]
        public String ModelVersionPics { get; set; }

        [Display(Name = "生产总数")]
        public int ProductedCount { get; set; }
        [Display(Name = "销售总数")]
        public int SaledCount { get; set; }

        [Display(Name = "工艺简述")]
        public String Comment { get; set; }
        [Display(Name = "工艺单文件")]
        public String TechnologyFile { get; set; }
        [Display(Name = "辅料卡文件")]
        public string AccessoriesFile { get; set; }

        [Display(Name = "样板文件")]
        public string SampleFile { get; set; }

        [Display(Name = "尺寸表")]
        public string ClothSize { get; set; }

        public string ClothesTags { get; set; }

        public int ClothesTypeId { get; set; }
    }

    public class ClothesDetailModel : Clothes
    {
        private Clothes _Clothes = null;
        public ClothesDetailModel() { }
        public ClothesDetailModel(Clothes c)
        {
            _Clothes = c;
        }

        public new int Id { get { return _Clothes.Id; } }
        public new string SampleNO { get { return _Clothes.SampleNO; } }
        public new string StyleNO { get { return _Clothes.ProductNO; } }
        public new int ProductedCount { get { return _Clothes.ProductedCount; } }
        public new int SaledCount { get { return _Clothes.SaledCount; } }
        public new String Comment { get { return _Clothes.Comment; } }
        public new String AssessoriesFile { get { return _Clothes.AssessoriesFile; } }
        public new String ClothesPics { get { return _Clothes.ClothesPics; } }
        public new String ModelVersionPics { get { return _Clothes.ModelVersionPics; } }
        public new String SampleFile { get { return _Clothes.SampleFile; } }
        public new String StylePics { get { return _Clothes.StylePics; } }
        public new String TechnologyFile { get { return _Clothes.TechnologyFile; } }
        public new String ClothesSize { get { return _Clothes.ClothesSize; } }
        public new String ProductNO { get { return _Clothes.ProductNO; } }
        public new int ViewCount { get { return _Clothes.ViewCount; } }
        public List<String> ClothesImages
        {
            get
            {
                if (_Clothes.ClothesPics != null)
                    return ClothesPics.Split(new char[] { ',' }).ToList();
                return new List<String> { "/Images/clothes0.png" };
            }
        }

        public List<string> StyleImages
        {
            get
            {
                if (_Clothes.StylePics != null)
                    return StylePics.Split(new char[] { ',' }).ToList();
                return new List<String> { "/Images/clothes0.png" };
            }
        }

        public List<string> ModelVersionImages
        {
            get
            {
                if (_Clothes.ModelVersionPics != null)
                    return ModelVersionPics.Split(new char[] { ',' }).ToList();
                return new List<String> { "/Images/clothes0.png" };
            }
        }

        public Dictionary<string, string> ClothesSizePairs
        {
            get
            {
                if (!String.IsNullOrEmpty(_Clothes.ClothesSize))
                {
                    var sizes = new Dictionary<string, string>();
                    var pairs = _Clothes.ClothesSize.Split(new char[] { ',' });
                    foreach (var t in pairs)
                    {
                        sizes.Add(t.Substring(0, t.IndexOf('=')), t.Substring(t.IndexOf('=') + 1));
                    }
                    return sizes;
                }
                return null;
            }
        }
    }
}