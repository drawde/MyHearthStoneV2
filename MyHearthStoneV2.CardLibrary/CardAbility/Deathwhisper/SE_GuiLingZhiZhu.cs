using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Servant;
using MyHearthStoneV2.CardLibrary.Servant.Neutral.NAXX;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.CardAbility.Deathwhisper
{
    public class SE_GuiLingZhiZhu : BaseSpecialEffect
    {
        public override List<SpellCardAbilityTime> LstSpellCardAbilityTime { get; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.坟场 };
        public override void CastAbility(GameContext gameContext, List<int> targetCardIndex)
        {
            string cardCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = new List<Card>();
                lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                cardCode = lstCardLib.First(c => c.GetType() == typeof(XiaoZhiZhu)).CardCode;
            }
            var userContext = gameContext.Players.First(c => c.IsActivation);
            int count = 0;
            while (userContext.DeskCards.Count < 8 && count < 2)
            {
                var spider = new XiaoZhiZhu() { CardCode = cardCode, CardInGameCode = gameContext.AllCard.Count.ToString() };
                userContext.DeskCards.Add(spider);
                userContext.AllCards.Add(spider);
                gameContext.AllCard.Add(spider);
                count++;
            }
        }
    }
}
