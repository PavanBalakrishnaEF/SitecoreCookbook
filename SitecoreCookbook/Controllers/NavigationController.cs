using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using SitecoreCookbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitecoreCookbook.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Carousel()
        {
            List<CarouselItem> slides = new List<CarouselItem>();
            MultilistField multilistField =
            Sitecore.Context.Item.Fields["Carousel Slides"];
            if (multilistField != null)
            {
                Item[] carouselItems = multilistField.GetItems();
                foreach (Item item in carouselItems)
                {
                    slides.Add(new CarouselSlide(item));
                }
            }
            return PartialView(slides);
        }
    }
}