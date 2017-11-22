using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Spell.Neutral.Classical;
using MyHearthStoneV2.Redis;

namespace MyHearthStoneV2.GameControler
{
    internal partial class Controler
    {
        /// <summary>
        /// 开局换牌
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="lstInitCardIndex"></param>        
        [ControlerMonitor, PlayerActionMonitor]
        internal void SwitchCard(string userCode, List<int> lstInitCardIndex)
        {
            UserCards uc = gameContext.Players.First(c => c.User.UserCode == userCode);
            uc.HandCards = uc.InitCards;
            if (lstInitCardIndex != null && lstInitCardIndex.Count > 0)
            {                
                int rndIndex = 0;
                List<int> newIdx = new List<int>();

                foreach (int i in lstInitCardIndex)
                {
                    //确保不会换到同一张牌
                    do
                    {
                        rndIndex = RandomUtil.CreateRandomInt(0, uc.StockCards.Count - 1);
                    }
                    while (newIdx.Contains(rndIndex));

                    newIdx.Add(rndIndex);
                    uc.InitCards[i] = uc.StockCards[rndIndex];
                }                

                //从牌库减去手牌
                foreach (int i in newIdx.OrderByDescending(c => c))
                {
                    uc.StockCards.RemoveAt(i);
                }                
            }
            //打乱牌库顺序
            uc.StockCards.Sort(delegate (Card a, Card b) { return RandomUtil.CreateRandomInt(-1, 1); });

            uc.HandCards.ForEach(c => { c.CardLocation = CardLocation.手牌; });

            uc.SwitchDone = true;

            //把开局摸到的牌清空
            uc.InitCards.Clear();

            //双方都换完牌后的流程
            if (gameContext.Players.First(c => c.User.UserCode != userCode).SwitchDone)
            {
                var firstUser = gameContext.Players.First(c => c.IsFirst);
                //先手玩家换完牌后再抽一张牌
                var addCard = firstUser.StockCards.First();
                addCard.CardLocation = CardLocation.手牌;
                firstUser.HandCards.Add(addCard);
                firstUser.StockCards.RemoveAt(0);

                var secondUser = gameContext.Players.First(c => c.IsFirst == false);
                //后手玩家添加一枚幸运币
                string cardCode = "";
                using (var redisClient = RedisManager.GetClient())
                {
                    List<Card> lstCardLib = new List<Card>();
                    lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                    cardCode = lstCardLib.First(c => c.GetType() == typeof(LuckyCoin)).CardCode;
                }
                secondUser.HandCards.Add(new LuckyCoin() { CardCode = cardCode });
                secondUser.IsActivation = false;

                RoundEnd();
            }
        }
    }
}
