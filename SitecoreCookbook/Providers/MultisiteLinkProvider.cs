//using Sitecore.Links;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace SitecoreCookbook.Providers
//{

//    public class MultisiteLinkProvider:LinkProvider
//    {
//        public override UrlOptions GetDefaultUrlOptions()
//        {
//            return GetMultiSiteLinkProvider().GetDefaultUrlOptions();
//        }
//        private LinkProvider GetMultiSiteLinkProvider()
//        {
//            if (Sitecore.Context.Site != null)
//            {
//                string siteName = Sitecore.Context.Site.Name.ToLower();
//                var providerName = Sitecore.Context.Site.Properties["linkProvider"];
//                if (!string.IsNullOrEmpty(providerName))
//                {
//                    var siteProvider =
//                    LinkManager.Providers[providerName];
//                    return siteProvider;
//                }
//            }
//            return LinkManager.Providers["sitecore"];
//        }
//    }
//}