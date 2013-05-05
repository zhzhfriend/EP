using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using Mock.Models.Entities;

namespace Mock.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        private EPContext _DataContext = null;
        protected EPContext DataContext
        {
            get
            {
                if (_DataContext == null)
                    _DataContext = new EPContext();

                return _DataContext;
            }
        }


    }
}
