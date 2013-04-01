using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mock.Models
{
    public class UserModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名必须填写")]
        public String UserName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码必须填写")]
        [DataType(DataType.Password)]
        public String PassWord { get; set; }
    }
}