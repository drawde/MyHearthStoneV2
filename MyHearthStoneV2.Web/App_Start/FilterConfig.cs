using MyHearthStoneV2.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace HearthStoneWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new WebException());
            filters.Add(new PageVariable());            
        }
    }
}
