using MyHearthStoneV2.API.Filters;
using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Game.CardLibrary;
using Newtonsoft.Json.Linq;
using MyHearthStoneV2.Common.Util;
using System.Web.Mvc;
using System;
using MyHearthStoneV2.Game;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Hero;

namespace MyHearthStoneV2.API.Controllers
{
    public class CardsController : Controller
    {
        [DataVerify]
        public ActionResult GetCard()
        {
            var cards = CardUtil.GetCardInRedis();
            var param = JObject.Parse(TempData["param"].TryParseString());
            string profession = param["Profession"].TryParseString();
            int cost = param["cost"].TryParseInt(-1);
            Profession pro = Profession.None;
            cards = cards.Where(c => c is BaseHero == false && c.IsDerivative == false).ToList();
            if (profession.IsNullOrEmpty() == false)
            {
                pro = (Profession)Enum.Parse(typeof(Profession), profession);
                cards = cards.Where(c => c.Profession == pro || c.Profession == Profession.Neutral).ToList();
            }
            if (cost > -1)
            {
                cards = cards.Where(c => c.Cost == cost).ToList();
            }
            cards = cards.OrderBy(c => c.Cost).OrderBy(c => c.Profession).ToList();
            return Content(JsonStringResult.SuccessResult(cards));
        }
    }
}