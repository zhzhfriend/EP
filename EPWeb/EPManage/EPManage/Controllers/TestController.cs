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
                       new ClothesType(){ Name="裙子",
                        ClothesParts = new List<ClothesPart>
                        {
                         new ClothesPart(){ Name="裙身", PartTypes=new List<ClothesPartType>
                         {
                              new ClothesPartType(){ Name="廓形",
                                  Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="直身裙"},
                                      new ClothesPartType(){ Name="A字裙"},
                                      new ClothesPartType(){ Name="A波浪"}
                                }
                              },
                              new ClothesPartType(){ Name="宽松风格",
                                   Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="宽松(H>98)"},
                                      new ClothesPartType(){ Name="较宽松（H=93~98）"},
                                      new ClothesPartType(){ Name="贴体（H=88~93）"}
                                }
                              },
                              new ClothesPartType(){ Name="裙长",
                                   Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="3分"},
                                      new ClothesPartType(){ Name="4分"},
                                      new ClothesPartType(){ Name="5分"},
                                      new ClothesPartType(){ Name="6~7分"},
                                      new ClothesPartType(){ Name="8~9分"},
                                      new ClothesPartType(){ Name="10分"}

                                }
                              },
                               new ClothesPartType(){ Name="造型特征",
                                   Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="分割",
                                          Children=new List<ClothesPartType>
                                         {
                                               new ClothesPartType(){ Name="横向"},
                                               new ClothesPartType(){ Name="纵向"},
                                               new ClothesPartType(){ Name="不规则"}
                                         }
                                      },
                                          new ClothesPartType(){ Name="省道"},
                                          new ClothesPartType(){ Name="折裥"},
                                          new ClothesPartType(){ Name="抽褶"}
                                }
                              }
                         }
                                     },
                         new ClothesPart(){ Name="腰头", PartTypes=new List<ClothesPartType>
                         {
                              new ClothesPartType(){ Name="腰高",
                                  Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="低腰"},
                                      new ClothesPartType(){ Name="中腰"},
                                      new ClothesPartType(){ Name="高腰"}
                                }
                              },
                              new ClothesPartType(){ Name="工艺",
                                   Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="装腰"},
                                      new ClothesPartType(){ Name="连腰"},
                                      new ClothesPartType(){ Name="约克"}
                                }
                              }
                         }
                                     }
                         }



                       },
                       new ClothesType(){ Name="裤子",
                              ClothesParts = new List<ClothesPart>
                        {
                         new ClothesPart(){ Name="裤身", PartTypes=new List<ClothesPartType>
                         {
                              new ClothesPartType(){ Name="廓形",
                                  Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="直筒裤"},
                                      new ClothesPartType(){ Name="窄脚裤"},
                                      new ClothesPartType(){ Name="喇叭裤"},
                                      new ClothesPartType(){ Name="哈伦裤"}
                                }
                              },
                              new ClothesPartType(){ Name="宽松风格",
                                   Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="宽松(H>98)"},
                                      new ClothesPartType(){ Name="较宽松（H=93~98）"},
                                      new ClothesPartType(){ Name="贴体（H=88~93）"}
                                }
                              },
                              new ClothesPartType(){ Name="裙长",
                                   Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="3分"},
                                      new ClothesPartType(){ Name="4分"},
                                      new ClothesPartType(){ Name="5分"},
                                      new ClothesPartType(){ Name="6~7分"},
                                      new ClothesPartType(){ Name="8~9分"},
                                      new ClothesPartType(){ Name="10分"}

                                }
                              },
                               new ClothesPartType(){ Name="造型特征",
                                   Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="分割",
                                          Children=new List<ClothesPartType>
                                         {
                                               new ClothesPartType(){ Name="横向"},
                                               new ClothesPartType(){ Name="纵向"},
                                               new ClothesPartType(){ Name="不规则"}
                                         }
                                      },
                                          new ClothesPartType(){ Name="省道"},
                                          new ClothesPartType(){ Name="折裥"},
                                          new ClothesPartType(){ Name="抽褶"}
                                }
                              }
                         }
                                     },
                         new ClothesPart(){ Name="腰头", PartTypes=new List<ClothesPartType>
                         {
                              new ClothesPartType(){ Name="腰高",
                                  Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="低腰"},
                                      new ClothesPartType(){ Name="中腰"},
                                      new ClothesPartType(){ Name="高腰"}
                                }
                              },
                              new ClothesPartType(){ Name="工艺",
                                   Children=new List<ClothesPartType>
                               {
                                      new ClothesPartType(){ Name="装腰"},
                                      new ClothesPartType(){ Name="连腰"},
                                      new ClothesPartType(){ Name="约克"}
                                }
                              }
                         }
                                     }
                         }



                       }
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
