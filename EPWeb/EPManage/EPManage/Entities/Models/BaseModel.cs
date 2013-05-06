using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPManageWeb.Entities.Models
{
    public abstract class BaseModel
    {
        public DateTime CreateDT { get; set; }
        public DateTime ModifiedDT { get; set; }
        public bool IsDeleted { get; set; }
    }
}