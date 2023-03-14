using System.Web;
using System.Web.Mvc;

namespace QLBH_PhanNhatThien_1951050077
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
