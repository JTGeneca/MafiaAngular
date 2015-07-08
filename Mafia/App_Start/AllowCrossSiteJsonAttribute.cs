using System.Web.Http.Filters;

namespace Mafia
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            filterContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            base.OnActionExecuted(filterContext);
        }
    }
}