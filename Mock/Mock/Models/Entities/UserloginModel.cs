

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mock.Models.Entities
{
    public class UserloginModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string PassWord { get; set; }
    }
}