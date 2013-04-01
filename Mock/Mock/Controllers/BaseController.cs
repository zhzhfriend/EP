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

        private modelDataContext _DataContext = null;
        protected modelDataContext DataContext
        {
            get
            {
                if (_DataContext == null)
                    _DataContext = new modelDataContext();

                var options = new DataLoadOptions();
                options.LoadWith<user_info>(p => p.id);
                _DataContext.LoadOptions = options;

                return _DataContext;
            }
        }


    }
}
