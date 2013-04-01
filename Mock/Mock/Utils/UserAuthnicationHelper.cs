using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TYAJZWeb.Data;

namespace TYAJZWeb.Utils
{
    public class UserAuthnicationHelper
    {
        private static String SESSION_ID = "UserId";

        public static void Login(User user, HttpContextBase context)
        {

            using (TYAJZDataContext dbContext = new TYAJZDataContext())
            {
                UserSession userSession = new UserSession()
                {
                    CreateDT = DateTime.Now,
                    Id = Guid.NewGuid(),
                    IsDeleted = false,
                    LastActivityDT = DateTime.Now,
                    LoginDT = DateTime.Now,
                    ModifiedDT = DateTime.Now,
                    RemoteIP = context.Request.ServerVariables["REMOTE_ADDR"],
                    UserId = user.Id,
                    Status = UserLoginStatus.Active.ToString()

                };
                dbContext.UserSessions.InsertOnSubmit(userSession);
                dbContext.SubmitChanges();

                HttpCookie cookie = new HttpCookie(SESSION_ID, userSession.Id.ToString());
                context.Response.AppendCookie(cookie);

            }
        }

        public static bool CheckUserLogin(HttpContextBase context)
        {
            using (TYAJZDataContext dbContext = new TYAJZDataContext())
            {
                if (context.Request.Cookies[SESSION_ID] != null)
                {
                    Guid userId = Guid.Parse(context.Request.Cookies[SESSION_ID].Value);
                    UserSession s = dbContext.UserSessions.SingleOrDefault(t => t.Id == userId);
                    if (s == null)
                        return false;
                    else
                    {
                        UserLoginStatus status = UserLoginStatus.LogoutManual;
                        Enum.TryParse<UserLoginStatus>(s.Status, true, out status);
                        if (status == UserLoginStatus.Active)
                        {
                            if ((DateTime.Now - s.LastActivityDT).Minutes > 20)
                            {
                                s.Status = UserLoginStatus.LogoutTimeOut.ToString();
                                dbContext.SubmitChanges();
                                return false;
                            }
                            else
                            {
                                s.LastActivityDT = DateTime.Now;
                                s.ModifiedDT = DateTime.Now;
                                dbContext.SubmitChanges();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static void Logout(HttpContextBase httpContext)
        {
            using (TYAJZDataContext dbContext = new TYAJZDataContext())
            {
                if (httpContext.Request.Cookies[SESSION_ID] != null)
                {
                    Guid userId = Guid.Parse(httpContext.Request.Cookies[SESSION_ID].Value);
                    UserSession s = dbContext.UserSessions.SingleOrDefault(t => t.Id == userId);
                    if (s != null)
                    {
                        s.Status = UserLoginStatus.LogoutManual.ToString();
                        dbContext.SubmitChanges();
                    }
                }
                HttpCookie cookie = new HttpCookie(SESSION_ID, "");
                cookie.Expires = DateTime.Now.AddDays(-1);
                httpContext.Response.AppendCookie(cookie);
            }

        }

        public enum UserLoginStatus
        {
            Active,       //激活  
            LogoutManual, //自动登出
            LogoutTimeOut,//超时登出
            LogoutForce   //强制登出
        }
    }
}