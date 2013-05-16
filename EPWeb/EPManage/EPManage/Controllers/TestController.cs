using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Xml.Serialization;
using EPManageWeb.Entities.Models;
using System.IO;

namespace EPManageWeb.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            var clothesTypes = new List<ClothesType>();
            clothesTypes.Add(new ClothesType()
            {
                Name = "上装",
                ClothesParts = new List<ClothesPart>
                    {
                         new ClothesPart(){ Name="品类", PartTypes=new List<ClothesPartType>
                         {
                              new ClothesPartType(){ Name="外套"},
                              new ClothesPartType(){ Name="衬衫"}
                         }}
                    }
            });
            clothesTypes.Add(new ClothesType()
            {
                Name = "下装",
                Children = new List<ClothesType>
                    {
                       new ClothesType(){ Name="裙子"},
                       new ClothesType(){ Name="裤子"}
                    }
            });
            XmlSerializer xs = new XmlSerializer(clothesTypes.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                xs.Serialize(stream, clothesTypes);
                stream.Position = 0;
                using (StreamReader sr = new StreamReader(stream))
                {
                    return new ContentResult() { Content = sr.ReadToEnd(), ContentType = "text/xml" };
                }
            }
        }

    }
}
