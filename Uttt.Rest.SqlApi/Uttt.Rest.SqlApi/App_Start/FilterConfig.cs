using System.Web;
using System.Web.Mvc;

namespace Uttt.Rest.SqlApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
