using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitecoreCookbook.Controllers
{
    public class MuseumRenderingController : Controller
    {
        // GET: MuseumRendering
        public ActionResult Gallery()
        {

            RenderingModel model = (RenderingModel)RenderingContext.Current.Rendering.Model;
            return View("~/Views/Museum/Main/_Gallery.cshtml",model);
        }
    }
}