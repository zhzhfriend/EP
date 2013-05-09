using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPManageWeb.Helper;

namespace EPManageWeb.Controllers
{
    public class UploadController : Controller
    {
        [CookiesAuthorize]
        public ActionResult Index()
        {
            UploadResult r = new UploadResult() { Success = false };
            String[] validExts = { ".jpg", ".gif", ".png", ".swf", ".avi", ".mpg" };
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpPostedFileBase file = Request.Files[0];
                    String ext = String.Empty;
                    if (file.FileName.LastIndexOf(".") > -1)
                        ext = file.FileName.Substring(file.FileName.LastIndexOf(@"."));
                    if (!validExts.Contains(ext.ToLower()))
                    {
                        throw new Exception("上传文件不合法，仅能上传图片、FLASH与视频文件");
                    }
                    String filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext;
                    file.SaveAs(Server.MapPath("~/Upload/" + filename));
                    r.FileName = "/Upload/" + filename; ;
                    r.Success = true;
                }
                catch (Exception e)
                {
                    r.ErrMsg = e.Message;
                    r.Success = false;
                }
                return new JsonResult() { Data = r, ContentType = "text/plain" };
            }
            return new JsonResult() { };
        }

    }

    class UploadResult
    {
        public bool Success { get; set; }
        public String FileName { get; set; }
        public String ErrMsg { get; set; }
    }
}
