using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyHearthStoneV2.BLL.PageAttribute
{
    public class AllowOriginAttribute
    {
        public static bool onExcute(ControllerContext context, string[] AllowSites)
        {
            var origin = context.HttpContext.Request.Headers["Origin"];

            if (AllowSites != null && AllowSites.Any())
            {
                if (AllowSites.Contains(origin))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
