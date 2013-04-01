using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWeb.Utils
{
    public interface IUserLogonLogoutUtil
    {
        void Logon(HttpResponseBase rsp, HttpSessionStateBase session, string userIdentityId);
        void Logout(HttpResponseBase rsp, HttpSessionStateBase session);
        String GetUserIdentityId(HttpRequestBase req, HttpSessionStateBase session);
    }
}