using MyHearthStoneV2.BLL.PageAttribute;
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
        public ActionResult Table(string cardGroup)
        {
            HS_Users user = ViewBag.User as HS_Users;
            ViewBag.SecretCode = user.SecretCode;
            ViewBag.lstCardGroup = UserCardGroupDetailBll.Instance.GetCardGroup(cardGroup, user.UserCode);
            return View();
        }

        public ActionResult Test(string param)
        {
            return Content(SignUtil.ConfusionString(param, DateTime.Now));
            //List<string> lst = SignUtil.ConfusionDateTime(DateTime.Now, DateTime.Now);
            //List<string> lst = new List<string>();
            //for (int i = 0; i < 10; i++)
            //{
            //    lst.Add(RandomUtil.CreateRandomInt(4,10000).ToString());
            //}
            //return Content(string.Join(",", lst));
            //byte[] array = new byte[1];
            //array[0] = (byte)(60);            
            //return Content(Encoding.ASCII.GetString(array));
        }
    }
}