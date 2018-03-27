using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Shell.Applications.ContentEditor.Gutters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCookbook.Gutter
{
    /// <summary>
    /// Class to check publish status of item to show in the 'gutter'
    /// </summary>
    public class PublishGutter: GutterRenderer
    {
        enum PublishStatus
        {
            Published,
            NeverPublished,
            Modified
        }

        /// <summary>
        /// Method to get publish status
        /// </summary>
        /// <param name="currentItem"></param>
        /// <returns></returns>
        private PublishStatus CheckPublishStatus(Item currentItem)
        {
            Database webDB = Factory.GetDatabase("web");
            Item webItem = webDB.GetItem(currentItem.ID);
            if (webItem == null)
                return PublishStatus.NeverPublished;
            if (currentItem["__Revision"] != webItem["__Revision"])
                return PublishStatus.Modified;
            return PublishStatus.Published;
        }

        /// <summary>
        /// Method to display gutter description
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override GutterIconDescriptor GetIconDescriptor(Item item)
        {
            GutterIconDescriptor desc = new GutterIconDescriptor();
            PublishStatus publishStatus = CheckPublishStatus(item);
            if (publishStatus != PublishStatus.Published)
            {
              
               
                if (publishStatus == PublishStatus.NeverPublished)
                {
                    desc.Icon = "Core2/32x32/flag_red_h.png";
                    desc.Tooltip = "Item never published!";
                }
                else if(publishStatus == PublishStatus.Modified)
                {
                    desc.Icon = "Core2/32x32/flag_yellow.png";
                    desc.Tooltip = "Item modified but not published !";
                }
                
            }
            else
            {
                desc.Icon= "Core2/32x32/flag_greeen.png";
                desc.Tooltip = "Item available on web";
            }
            desc.Click = string.Format("item:load(id={0})", item.ID);
            return desc;
        }
    }
}