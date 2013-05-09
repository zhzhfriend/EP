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
        [Display(Name = "样式编号")]
        public String StyleNO { get; set; }

        [Display(Name = "款式图")]
        public String StylePicsIds { get; set; }
        [Display(Name = "成衣图片")]
        public String ClothesPicsIds { get; set; }
        [Display(Name = "版型图")]
        public String ModelVersionPicsIds { get; set; }

        [Display(Name = "生产总数")]
        public int ProductedCount { get; set; }
        [Display(Name = "销售总数")]
        public int SaledCount { get; set; }

        [Display(Name = "工艺简述")]
        public int Comment { get; set; }
        [Display(Name = "工艺单文件")]
        public int TechnologyFileIds { get; set; }
        [Display(Name = "辅料卡文件")]
        public int AccessoriesFileIds { get; set; }

        [Display(Name = "样板文件")]
        public string SampleFileId { get; set; }
    }
}