﻿using MyHearthStoneV2.BLL.PageAttribute;
using System.Web;
using System.Web.Mvc;

namespace HearthStoneWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PageVariable());            
        }
    }
}
