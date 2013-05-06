﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EPManageWeb.Entities.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String RealName { get; set; }

        public DbSet<SessionUser> Sessions { get; set; }

    }
}