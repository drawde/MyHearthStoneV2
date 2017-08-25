using MyHearthStoneV2.BLL.PageAttribute;
using System.Web;
using System.Web.Mvc;

namespace MyHearthStoneV2.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ActionAllowOriginAttribute());
            filters.Add(new RecordDataExchangeAttribute());
            filters.Add(new ExceptionAttribute());
        }
    }
}
