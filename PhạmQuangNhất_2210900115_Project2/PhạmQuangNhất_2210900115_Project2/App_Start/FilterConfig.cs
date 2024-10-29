using System.Web;
using System.Web.Mvc;

namespace PhạmQuangNhất_2210900115_Project2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
