using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using web.artimeagallery.com.Models;

namespace web.artimeagallery.com
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            using (var _db = new ArtemiaContext())
            {
                HttpRuntime.Cache.Insert(
                    "artists",
                    _db.Artists.ToList(),
                    null,
                    /* absoluteExpiration */ Cache.NoAbsoluteExpiration,
                    /* slidingExpiration */  Cache.NoSlidingExpiration,
                    /* priority */           CacheItemPriority.NotRemovable,
                    /* onRemoveCallback */   null);
            }

        }
    }
}
