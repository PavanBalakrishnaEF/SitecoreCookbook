using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCookbook.Models.Museum
{
    public class SitemapList : RenderingModel
    {
        

        public List<Sitemap> SiteMapItems { get {
                return GetSitemap();
            }
        }

        public HtmlString CurrentPageName { get { return new HtmlString(Sitecore.Context.Item.DisplayName); } }


        private List<Sitemap> GetSitemap()
        {
            string homePath = Sitecore.Context.Site.StartPath;
            Item homeitem = Sitecore.Context.Database.GetItem(homePath);

            return Sitecore.Context.Item.Axes.GetAncestors()
                  .SkipWhile(i => i.ID != homeitem.ID)
                  .Select(i => new Sitemap(i)).ToList();
        }
    }
}