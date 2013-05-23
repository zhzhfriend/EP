using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPManageWeb.Entities.Models;

namespace EPManageWeb.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reg(User user)
        {
            if (!String.IsNullOrEmpty(user.UserName) && !String.IsNullOrEmpty(user.Password))
            {
                if (DbContext.Users.SingleOrDefault(t => t.UserName == user.UserName) == null)
                {
                    user.UserType = UserType.User.ToString();
                    DbContext.Users.Add(user);
                    DbContext.SaveChanges();
                    return new ContentResult() { Content = "true" };
                }
                else
                {
                    return new ContentResult() { Content = "该用户名已存在" };
                }
            }
            else
            {
                return new ContentResult() { Content = "用户名和密码不得为空" };
            }
        }
    }
}
