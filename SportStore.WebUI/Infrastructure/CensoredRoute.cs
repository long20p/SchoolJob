using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportStore.WebUI.Infrastructure
{
    public class CensoredRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var requestURL = httpContext.Request.AppRelativeCurrentExecutionFilePath;
            if(requestURL.Contains("Sex"))
            {
                var routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("controller", "Product");
                routeData.Values.Add("action", "List");
                return routeData;
            }
            return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}