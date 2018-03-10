using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitecoreCookbook.Controllers
{
    public class CookBookController : Controller
    {
        // GET: CookBook
        public ActionResult Index()
        {
            return View();
        }
    }
}