
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Servant;
using MyHearthStoneV2.CardLibrary.Spell;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 获取当前回合的用户对象
        /// </summary>
        /// <returns></returns>
        public UserContext GetCurrentTurnUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation);
        }

        /// <summary>
        /// 获取下个回合或是后手的用户对象
        /// </summary>
        /// <returns></returns>
        public UserContext GetNextTurnUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation == false || c.IsFirst == false);
        }

        /// <summary>
        /// 创造一张牌到游戏中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateNewCardInController<T>() where T : Card
        {
            T card = Activator.CreateInstance<T>();
            string cardCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                cardCode = lstCardLib.First(c => c.GetType() == typeof(T)).CardCode;
            }
            card.CardCode = cardCode;
            card.CardInGameCode = gameContext.AllCard.Count.ToString();
            return card;
        }

        /// <summary>
        /// 判断这张牌是否是当前回合玩家打出的牌
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool IsThisActivationUserCard(Card card)
        {
            return gameContext.Players.Any(c => c.IsActivation && c.AllCards.Any(x => x.CardInGameCode == card.CardInGameCode));
        }

        public bool IsThisActivationUserCard(List<Card> cards)
        {
            return gameContext.Players.Any(c => c.IsActivation && c.AllCards.Any(x => cards.Any(n => n.CardInGameCode == x.CardInGameCode)));
        }

        /// <summary>
        /// 根据下标获取场上的牌
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public Card GetCardByLocation(int location)
        {
            if (location < 8)
                return gameContext.Players.First(c => c.IsFirst == true).DeskCards[location];
            else
                return gameContext.Players.First(c => c.IsFirst == false).DeskCards[location - 8];
        }

        /// <summary>
        /// 触发卡牌技能
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="spellTime"></param>
        /// <param name="triggerCard"></param>
        /// <param name="target"></param>
        public void TriggerCardAbility(IEnumerable<Card> lstCard, CardLocation cl, SpellCardAbilityTime spellTime, Card triggerCard = null, List<int> target = null)
        {
            var lstCards = lstCard.Where(c => c.CardLocation == cl);
            foreach (Card card in lstCards)
            {
                foreach (var buff in card.Abilities.Where(c => c.LstSpellCardAbilityTime.Any(x => x == spellTime)))
                {
                    buff.CastAbility(gameContext, triggerCard, card, target);
                }
            }
        }

        /// <summary>
        /// 移除（沉默、BUFF时间过期）卡牌技能
        /// </summary>
        /// <param name="lstCard"></param>
        /// <param name="cl"></param>
        /// <param name="spellTime"></param>
        public void DisableCardAbility(IEnumerable<Card> lstCard, CardLocation cl, BuffTimeLimit buffTime)
        {
            var lstCards = lstCard.Where(c => c.CardLocation == cl);
            foreach (Card card in lstCards)
            {
                foreach (var buff in card.Buffs.Where(c => c.Value.buffTime == buffTime))
                {
                    buff.Value.CastAbility(gameContext, null, card, null);
                }
                card.Buffs.Clear();
            }
        }
        //public void TryTriggerCardAbility(Card card, SpellCardAbilityTime spellCardAbilityTime)
        //{

        //}
    }
}
