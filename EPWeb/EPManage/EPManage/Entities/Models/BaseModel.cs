using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPManageWeb.Entities.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            IsDeleted = false;
            CreateDT = DateTime.Now;
            ModifiedDT = DateTime.Now;
        }

        public DateTime CreateDT { get; set; }
        public DateTime ModifiedDT { get; set; }
        public bool IsDeleted { get; set; }
    }
}