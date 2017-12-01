using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Hero;
using MyHearthStoneV2.CardLibrary.Servant.Neutral.Classical;
using MyHearthStoneV2.CardLibrary.Servant.Neutral.NAXX;
using MyHearthStoneV2.CardLibrary.Servant.Shaman.Classical;
using MyHearthStoneV2.CardLibrary.Spell.Neutral.Classical;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using MyHearthStoneV2.ShortCodeBll;
using System.Collections.Generic;


namespace MyHearthStoneV2.BLL
{
    public class CardUtil
    {
        /// <summary>
        /// 将卡牌对象添加进缓存
        /// </summary>
        public static void AddToRedis()
        {
            List<Card> lstCard = new List<Card>
            {
                new Hunter(),
                new Warlock(),
                new Al_akir(),
                new JiaoXiaoDeZhongShi(),
                new GuiLingZhiZhu(),
                new XiaoZhiZhu(),
                new LuckyCoin(),
                new DefenderOfArgus(),
                new VioletTeacher(),
                new VioletStudent(),
                new Mage(),
                new Paladin(),
                new Priest(),
                new Rogue(),
                new Shaman(),
                new Warlock(),
                new Warrior(),
            };

            lstCard.ForEach(c => c.CardCode = ShortCodeBusiness.Instance.GetOrCreate(c.GetType().FullName, ShortCodeTypeEnum.卡牌).Code);
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance), lstCard);
            }
        }

        /// <summary>
        /// 从缓存中加载卡牌对象
        /// </summary>
        /// <returns></returns>
        public static List<Card> GetCardInRedis()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                return redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
            }
        }
    }
}
