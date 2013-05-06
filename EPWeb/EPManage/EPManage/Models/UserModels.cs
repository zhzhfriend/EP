using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPManageWeb.Models
{
    public class UserLoginModel
    {
        [Display(Name = "用户名")]
        public String UserName { get; set; }

        [Display(Name = "密码")]
        public String PassWord { get; set; }
    }
}