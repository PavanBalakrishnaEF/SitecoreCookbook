using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SitecoreCookbook.Pipelines
{
    public class PageNotFoundResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            string filePath =HttpContext.Current.Server.MapPath(args.Url.FilePath);
            if ((IsValidItem()|| args.LocalPath.StartsWith("/sitecore")|| File.Exists(filePath))&& args.LocalPath!= "/notfound")
                return;

            var pnfItem = Get404Page();

            if (pnfItem!=null)
            {
                Context.Item = pnfItem;
                Sitecore.Context.Items["Is404Page"] = "true";
            }
    
        }

        private Item Get404Page()
        {
            try
            {
                string itemPath = Context.Site.StartPath + "/404-Page";
                return Context.Database.GetItem(itemPath);
            }
            catch (Exception ex)
            {

                
            }
            return null;
            
        }

        private bool IsValidItem()
        {
            if (Context.Item == null || Context.Item.Versions.Count == 0)
                return false;
            if (Context.Item.Visualization.Layout == null)
                return false;
            return true;
        }
    }
}