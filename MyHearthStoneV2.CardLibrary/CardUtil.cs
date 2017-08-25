using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Hero;
using MyHearthStoneV2.CardLibrary.Servant.Classical;
using MyHearthStoneV2.CardLibrary.Servant.NAXX;
using MyHearthStoneV2.CardLibrary.Spell.Classical;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary
{
    public class CardUtil
    {
        /// <summary>
        /// 将卡牌对象添加进缓存
        /// </summary>
        public static void AddToRedis()
        {
            List<Card> lstCard = new List<Card>();
            lstCard.Add(new Hunter());
            lstCard.Add(new Warlock());
            lstCard.Add(new Al_akir());
            lstCard.Add(new JiaoXiaoDeZhongShi());
            lstCard.Add(new GuiLingZhiZhu());
            lstCard.Add(new XiaoZhiZhu());
            lstCard.Add(new LuckyCoin());

            lstCard.ForEach(c => c.CardCode = SignUtil.CreateSign(c.Name + c.GetType().Name));
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set<List<Card>>(RedisKeyEnum.CardsInstance.ToString(), lstCard);
            }
        }
    }
}
