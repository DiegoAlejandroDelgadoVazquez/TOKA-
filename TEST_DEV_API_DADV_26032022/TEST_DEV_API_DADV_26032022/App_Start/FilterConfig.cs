using System.Web;
using System.Web.Mvc;

namespace TEST_DEV_API_DADV_26032022
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
