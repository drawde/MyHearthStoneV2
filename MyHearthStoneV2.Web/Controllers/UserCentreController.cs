using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHearthStoneV2.HearthStoneWeb.Controllers
{
    public class UserCentreController : Controller
    {
        // GET: UserCentre
        public ActionResult Register()
        {
            return View();
        }
    }
}