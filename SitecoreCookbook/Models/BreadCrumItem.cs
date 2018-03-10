using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCookbook.Models
{
    public class BreadCrumItem:CustomItem
    {
        public BreadCrumItem(Item item):base(item)
        {
            Assert.IsNotNull(item, "item");
        }

        public string Title
        { get { return InnerItem["Title"]; } }
        public bool IsActive
        { get { return Sitecore.Context.Item.ID == InnerItem.ID; } }
        public string Url
        { get { return LinkManager.GetItemUrl(InnerItem); } }
    }
}