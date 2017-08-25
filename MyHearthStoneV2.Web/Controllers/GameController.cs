using MyHearthStoneV2.BLL.PageAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHearthStoneV2.HearthStoneWeb.Controllers
{
    public class GameController : Controller
    {
        [OAuth]
        public ActionResult Table()
        {
            return View();
        }
    }
}