using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWeb.Utils
{
    class UserUtilsBasedCookie : IUserLogonLogoutUtil
    {
        public const string COOKIE_NAME = "UserID";

        public void Logon(HttpResponseBase rsp, HttpSessionStateBase session, string userIdentityId)
        {
            rsp.Cookies.Add(new HttpCookie(COOKIE_NAME, userIdentityId));
        }

        public void Logout(HttpResponseBase rsp, HttpSessionStateBase session)
        {
            HttpCookie cookie = new HttpCookie(COOKIE_NAME, string.Empty);
            cookie.Expires = DateTime.Now.AddDays(-1);
            rsp.Cookies.Add(cookie);
        }

        public String GetUserIdentityId(HttpRequestBase req, HttpSessionStateBase session)
        {
            if (req.Cookies[COOKIE_NAME] != null)
                return req.Cookies[COOKIE_NAME].Value;

            return string.Empty;
        }
    }

    class UesrLoginLogoutArgs : EventArgs
    {
        public HttpRequestBase Req;
        public HttpResponseBase Rsp;
        public String UserIdentityID;
    }
}