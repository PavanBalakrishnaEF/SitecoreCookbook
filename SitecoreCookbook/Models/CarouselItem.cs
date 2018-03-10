using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCookbook.Models
{
    public class CarouselItem : CustomItem
    {
        protected CarouselItem(Item innerItem) : base(innerItem)
        {
        }

        public string Title
        {
            get { return InnerItem["Title"]; }
        }
        public HtmlString Image
        {
            get
            {
                return new HtmlString(FieldRenderer.Render(InnerItem,
                "Image"));
            }
        }

        public string Url
        {
            get
            {
                Item linkItem = Sitecore.Context.Database.GetItem(
                InnerItem["Link Item"]);
                if (linkItem != null)
                    return LinkManager.GetItemUrl(linkItem);
                return "No Link";
            }
        }
    }
}