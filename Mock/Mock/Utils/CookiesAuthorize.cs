using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TYAJZWeb.Utils
{
    public class CookiesAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return UserAuthnicationHelper.CheckUserLogin(httpContext);
        }
    }
}