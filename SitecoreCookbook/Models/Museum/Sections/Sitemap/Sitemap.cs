using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCookbook.Models.Museum.Sections.Sitemap
{
    public class Sitemap
    {
        private Item SitecoreItem;
        public Sitemap(Item item)
        {
            this.SitecoreItem = item;
        }
        public HtmlString PageName
        {
            get
            {
                return new HtmlString(FieldRenderer.Render(SitecoreItem,"Title"));
            }
        }

        public string Link
        {
            get
            {
                return LinkManager.GetItemUrl(SitecoreItem);
            }
        }
    }
}