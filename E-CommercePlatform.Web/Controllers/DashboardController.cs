using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommercePlatform.Web.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        public ActionResult DashboardIndex()
        {
            return View();
        }
    }
}