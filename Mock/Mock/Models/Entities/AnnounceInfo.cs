using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mock.Models.Entities
{
    public class AnnounceInfo
    {
        public int ID { get;set; }
        public string Title{get;set;}
        public string Content{get;set;}
        public int Category{get ;set;}
    }
}