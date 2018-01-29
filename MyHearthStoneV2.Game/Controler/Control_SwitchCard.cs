using MyHearthStoneV2.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Spell.Neutral.Classical;
using MyHearthStoneV2.Redis;
using MyHearthStoneV2.Game.Monitor;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter.Controler;

namespace MyHearthStoneV2.Game.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 开局换牌
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="lstInitCardIndex"></param>        
        [ControlerMonitor, PlayerActionMonitor, UserActionMonitor]
        internal void SwitchCard(string userCode, List<int> lstInitCardIndex)
        {
            UserContext uc = GameContext.Players.First(c => c.User.UserCode == userCode);
            uc.InitCards.ForEach(c => uc.HandCards.Add(c));
            if (lstInitCardIndex != null && lstInitCardIndex.Count > 0)
            {
                List<int> newIdx = RandomUtil.CreateRandomInt(0, uc.StockCards.Count - 1, lstInitCardIndex.Count);
                for (int i = 0; i < lstInitCardIndex.Count; i++)
                {
                    uc.HandCards[lstInitCardIndex[i]] = uc.StockCards[newIdx[i]];
                }
            }

            //从牌库减去手牌
            foreach (var card in uc.HandCards)
            {
                uc.StockCards.RemoveAt(uc.StockCards.FindIndex(c => c.CardInGameCode == card.CardInGameCode));
            }

            //打乱牌库顺序
            uc.StockCards.Sort(delegate (Card a, Card b) { return RandomUtil.CreateRandomInt(-1, 1); });

            uc.HandCards.ForEach(c => { c.CardLocation = CardLocation.手牌; });

            uc.SwitchDone = true;

            //把开局摸到的牌清空
            uc.InitCards.Clear();

            //双方都换完牌后的流程
            if (GameContext.Players.First(c => c.User.UserCode != userCode).SwitchDone)
            {
                var firstUser = GameContext.Players.First(c => c.IsFirst);
                //先手玩家换完牌后再抽一张牌
                var addCard = firstUser.StockCards.First();
                addCard.CardLocation = CardLocation.手牌;
                firstUser.HandCards.Add(addCard);
                firstUser.StockCards.RemoveAt(0);

                var secondUser = GameContext.Players.First(c => c.IsFirst == false);
                //后手玩家添加一枚幸运币
                var luckyCoin = new CreateNewCardInControllerAction<LuckyCoin>().Action(new ControlerActionParameter() { GameContext = GameContext, UserContext = secondUser }) as LuckyCoin;
                secondUser.HandCards.Add(luckyCoin);
                GameContext.AllCard.Add(luckyCoin);
                secondUser.IsActivation = false;

                TurnEnd();
            }
            //UpdateOutput();
        }
    }
}
