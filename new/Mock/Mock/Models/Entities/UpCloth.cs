using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mock.Data;
using System.ComponentModel.DataAnnotations;

namespace Mock.Models.Entities
{
    public abstract class UpClothBaseModel
    {
        public int SYTLE_NO { get; set; }
        public int BIG_NO { get; set; }
        public string STYLE { get; set; }
        public string C_CLASS { get; set; }
        public string KUOXING { get; set; }
        public string KUANSONGFENGGE { get; set; }
        public string YISHENPIANSHU { get; set; }
        public string YISHENZAOXING { get; set; }
        public string LINGXING { get; set; }
        public string XIUXING { get; set; }
        public string PIANSHU { get; set; }
        public string CHANGDUAN { get; set; }
        public string YIXIUZAOXING { get; set; }
        public string COMMENTS { get; set; }
        public string YANGYI_LOCATION { get; set; }
        public string YANGYI_INFO { get; set; }
        public string KUANSHI_LOCATION { get; set; }
        public string KUANSHI_INFO { get; set; }
        public string BANXING_LOCAITON { get; set; }
        public string BANXING_INFO { get; set; }
        public string GONGYIWENJIAN { get; set; }
        public string GONGYIWENJIAN_INFO { get; set; }
        public string FULIAOKA { get; set; }
        public string FULIAOKA_INFO { get; set; } 
    }

    public class UpClothListModel : UpClothBaseModel
    {
        public int SYTLE_NO { get; set; }
        public int BIG_NO { get; set; }

        public static explicit operator UpClothListModel(UpCloth model)
        {
            UpClothListModel m = new UpClothListModel()
            {
                SYTLE_NO = model.SYTLE_NO,
                 BIG_NO = model.BIG_NO,
                 STYLE = model.STYLE,
                 C_CLASS = model.C_CLASS,
                 KUOXING = model.KUOXING,
                 KUANSONGFENGGE = model.KUANSONGFENGGE,
                 YISHENPIANSHU = model.YISHENPIANSHU,
                 YISHENZAOXING = model.YISHENZAOXING,
                 LINGXING = model.LINGXING,
                 XIUXING = model.XIUXING,
                 PIANSHU = model.PIANSHU,
                 CHANGDUAN = model.CHANGDUAN,
                 YIXIUZAOXING = model.YIXIUZAOXING,
                 COMMENTS = model.COMMENTS,
                 YANGYI_LOCATION = model.YANGYI_LOCATION,
                 YANGYI_INFO = model.YANGYI_INFO,
                 KUANSHI_LOCATION = model.KUANSHI_LOCATION,
                 KUANSHI_INFO = model.KUANSHI_INFO,
                 BANXING_LOCAITON = model.BANXING_LOCAITON,
                 BANXING_INFO = model.BANXING_INFO,
                 GONGYIWENJIAN = model.GONGYIWENJIAN,
                 GONGYIWENJIAN_INFO = model.GONGYIWENJIAN_INFO,
                 FULIAOKA = model.FULIAOKA,
                 FULIAOKA_INFO  = model.FULIAOKA_INFO
            };
            return m;
        }
    }

    public class UpClothEditModel : UpClothBaseModel
    {
        [Display(Name = "产权单位")]
        [Required(AllowEmptyStrings = true)]
        public int Eq_OwnerCompanyId { get; set; }


        public int SYTLE_NO { get; set; }
        public int BIG_NO { get; set; }


        public static explicit operator UpCloth(UpClothEditModel model)
        {
            return new UpCloth()
            {
                SYTLE_NO = model.SYTLE_NO,
                BIG_NO = model.BIG_NO,
                STYLE = model.STYLE,
                C_CLASS = model.C_CLASS,
                KUOXING = model.KUOXING,
                KUANSONGFENGGE = model.KUANSONGFENGGE,
                YISHENPIANSHU = model.YISHENPIANSHU,
                YISHENZAOXING = model.YISHENZAOXING,
                LINGXING = model.LINGXING,
                XIUXING = model.XIUXING,
                PIANSHU = model.PIANSHU,
                CHANGDUAN = model.CHANGDUAN,
                YIXIUZAOXING = model.YIXIUZAOXING,
                COMMENTS = model.COMMENTS,
                YANGYI_LOCATION = model.YANGYI_LOCATION,
                YANGYI_INFO = model.YANGYI_INFO,
                KUANSHI_LOCATION = model.KUANSHI_LOCATION,
                KUANSHI_INFO = model.KUANSHI_INFO,
                BANXING_LOCAITON = model.BANXING_LOCAITON,
                BANXING_INFO = model.BANXING_INFO,
                GONGYIWENJIAN = model.GONGYIWENJIAN,
                GONGYIWENJIAN_INFO = model.GONGYIWENJIAN_INFO,
                FULIAOKA = model.FULIAOKA,
                FULIAOKA_INFO = model.FULIAOKA_INFO
            };
         }



        public static explicit operator UpClothEditModel(UpCloth model)
        {
            return new UpClothEditModel()
            {
                SYTLE_NO = model.SYTLE_NO,
                BIG_NO = model.BIG_NO,
                STYLE = model.STYLE,
                C_CLASS = model.C_CLASS,
                KUOXING = model.KUOXING,
                KUANSONGFENGGE = model.KUANSONGFENGGE,
                YISHENPIANSHU = model.YISHENPIANSHU,
                YISHENZAOXING = model.YISHENZAOXING,
                LINGXING = model.LINGXING,
                XIUXING = model.XIUXING,
                PIANSHU = model.PIANSHU,
                CHANGDUAN = model.CHANGDUAN,
                YIXIUZAOXING = model.YIXIUZAOXING,
                COMMENTS = model.COMMENTS,
                YANGYI_LOCATION = model.YANGYI_LOCATION,
                YANGYI_INFO = model.YANGYI_INFO,
                KUANSHI_LOCATION = model.KUANSHI_LOCATION,
                KUANSHI_INFO = model.KUANSHI_INFO,
                BANXING_LOCAITON = model.BANXING_LOCAITON,
                BANXING_INFO = model.BANXING_INFO,
                GONGYIWENJIAN = model.GONGYIWENJIAN,
                GONGYIWENJIAN_INFO = model.GONGYIWENJIAN_INFO,
                FULIAOKA = model.FULIAOKA,
                FULIAOKA_INFO = model.FULIAOKA_INFO
            };
        }
    }
}