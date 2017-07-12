using MyHearthStoneV2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHearthStoneV2.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            new hs_invitation_BLL().CreateInvitationCode("58657C04BCADF3C6AA26F2B79D24994D");
            return View();
        }
    }
}
