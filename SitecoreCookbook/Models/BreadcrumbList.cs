using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCookbook.Models
{
    public class BreadcrumbList:RenderingModel
    {
        public IList<BreadCrumItem> Breadcrumbs { get; set; }

        public override void Initialize(Rendering rendering)
        {
            Breadcrumbs = new List<BreadCrumItem>();
            List<Item> items = GetBreadcrumbItems();
            foreach (Item item in items)
            {
                Breadcrumbs.Add(new BreadCrumItem(item));
            }
            Breadcrumbs.Add(new
            BreadCrumItem(Sitecore.Context.Item));
            base.Initialize(rendering);
        }


        /// <summary>
        /// Method to get list of path items with respect to the current item
        /// </summary>
        /// <returns></returns>
        private List<Item> GetBreadcrumbItems()
        {
            string homePath = Sitecore.Context.Site.StartPath;

            Item homeitem = Sitecore.Context.Database.GetItem(homePath);

            return Sitecore.Context.Item.Axes.GetAncestors()
                    .SkipWhile(i => i.ID != homeitem.ID)
                    .ToList();
               
        }
    }
}