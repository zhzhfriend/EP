using EPManageWeb.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EPManageWeb.Entities
{
    public class EPDataContext : DbContext
    {
        public DbSet<SessionUser> SessionUsers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}