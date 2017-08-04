using MyHearthStoneV2.BLL;
using MyHearthStoneV2.CardAction.Servant.NAXX;
using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Servant.Classical;
using MyHearthStoneV2.CardLibrary.Servant.NAXX;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.GameControler;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CardUtil.AddToRedis();

            //List<Card> lstCard = new List<Card>();
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new GuiLingZhiZhu());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new JiaoXiaoDeZhongShi());
            //lstCard.Add(new Al_akir());
            //lstCard.Add(new Al_akir());
            //lstCard.Add(new Al_akir());
            //lstCard.Add(new Al_akir());

            //lstCard.ForEach(c => { c.UserCode = drawde.UserCode; });
            //string json = JsonConvert.SerializeObject(lstCard);
            //HS_Users drawde = null;

            //HS_UsersBll.Instance.Register("nimda", "zaq1xsw2", "18692609891", "drawde2@126.com", "D2C4EBCDEA0DC37CF19AC5272164A487");

            //var drawde = HS_UsersBll.Instance.GetUserByUserName("nimda");
            //HS_UserCardGroup group = new HS_UserCardGroup();
            //group.AddTime = DateTime.Now;
            //group.GroupCode = SignUtil.CreateSign(drawde.UserCode + RandomUtil.RandomStr(10) + DateTime.Now.Ticks);
            //group.GroupName = "T7";
            //group.UserCode = drawde.UserCode;
            //UserCardGroupBll.Instance.Insert(group);

            //foreach (var card in lstCard)
            //{
            //    HS_UserCardGroupDetail detail = new HS_UserCardGroupDetail();
            //    detail.AddTime = DateTime.Now;
            //    detail.CardCode = SignUtil.CreateSign(card.Name + card.GetType().Name);
            //    detail.GroupCode = group.GroupCode;
            //    detail.IsGoldCard = false;
            //    detail.UserCode = drawde.UserCode;
            //    UserCardGroupDetailBll.Instance.Insert(detail);
            //}

            //var drawde = HS_UsersBll.Instance.GetUserByUserName("drawde");
            //var nimda = HS_UsersBll.Instance.GetUserByUserName("nimda");
            //string res = ControllerProxy.CreateGame(drawde.UserCode, nimda.UserCode, "BFAA44277D31F83175F23B719E0B90D0", "D882AC366F1F7E4D15EEE472AC98A63E");
            var xxx = ControllerCache.GetController();

            string rnd = RandomUtil.CreateRandomStr(10);


            Console.ReadKey();
        }
    }
}
