using MyHearthStoneV2.HearthStoneWeb.Filters;
using MyHearthStoneV2.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyHearthStoneV2.Model;
using Newtonsoft.Json;
using MyHearthStoneV2.Model.CustomModels;
using MyHearthStoneV2.BLL;
using System.Text;

namespace MyHearthStoneV2.HearthStoneWeb.Controllers
{
    public class GameController : Controller
    {
        [OAuth]
        public ActionResult Battle(string gameCode)
        {
            return View();
        }

        [OAuth]
        public ActionResult Saloon()
        {
            return View();
        }

        [OAuth]
        public ActionResult ChosenCardGroup()
        {
            return View();
        }
    }
}