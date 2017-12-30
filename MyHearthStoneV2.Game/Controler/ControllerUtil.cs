
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.Controler
{
    public static class Controler_Util
    {
        /// <summary>
        /// 创造一张牌到场内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controler"></param>
        /// <param name="isActivation">是否是当前回合玩家的牌</param>
        /// <returns></returns>
        public static T CreateNewCardInDesk<T>(this GameContext context, bool isActivation = true) where T : BaseBiology
        {
            T card = Activator.CreateInstance<T>();
            string cardCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                cardCode = lstCardLib.First(c => c.GetType() == typeof(T)).CardCode;
            }
            card.CardCode = cardCode;
            card.CardInGameCode = context.AllCard.Count.ToString();
            var player = context.Players.First(c => c.IsActivation == isActivation);
            int deskIndex = player.DeskCards.FindIndex(c => c == null);
            if (card.CardType == CardType.随从)
            {
                BaseServant servant = card as BaseServant;
                if (player.IsFirst == false)
                {
                    servant.DeskIndex = deskIndex + 8;
                }
                else
                {
                    servant.DeskIndex = deskIndex;
                }
            }
            player.DeskCards[deskIndex] = card;
            player.AllCards.Add(card);
            context.AllCard.Add(card);
            return card;
        }

        /// <summary>
        /// 创造一张牌到游戏中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateNewCardInController<T>(this GameContext context) where T : Card
        {
            T card = Activator.CreateInstance<T>();
            string cardCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                cardCode = lstCardLib.First(c => c.GetType() == typeof(T)).CardCode;
            }
            card.CardCode = cardCode;
            card.CardInGameCode = context.AllCard.Count.ToString();
            return card;
        }

        /// <summary>
        /// 获取当前回合玩家
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static UserContext GetActivationUserContext(this GameContext context)
        {
            return context.Players.First(c => c.IsActivation);
        }

        /// <summary>
        /// 获取不是当前回合的玩家
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static UserContext GetNotActivationUserContext(this GameContext context)
        {
            if (context.Players.Any(c => c.IsActivation == false))
                return context.Players.First(c => c.IsActivation == false);
            return context.Players.First(c => c.IsFirst == false);
        }

        /// <summary>
        /// 判断这张牌是否是当前回合玩家打出的牌
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool IsThisActivationUserCard(this GameContext context, Card card)
        {
            return context.Players.Any(c => c.IsActivation && c.AllCards.Any(x => x.CardInGameCode == card.CardInGameCode));
        }

        public static bool IsThisActivationUserCard(this GameContext context, List<Card> cards)
        {
            return context.Players.Any(c => c.IsActivation && c.AllCards.Any(x => cards.Any(n => n.CardInGameCode == x.CardInGameCode)));
        }

        /// <summary>
        /// 根据下标获取场上的牌
        /// </summary>
        /// <param name="context"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public static Card GetCardByLocation(this GameContext context, int location)
        {
            if (location < 8)
                return context.Players.First(c => c.IsFirst == true).DeskCards[location];
            else
                return context.Players.First(c => c.IsFirst == false).DeskCards[location - 8];
        }

        /// <summary>
        /// 根据自己的牌获取敌方的用户环境对象
        /// </summary>
        /// <param name="context"></param>
        /// <param name="myCard"></param>
        /// <returns></returns>
        public static UserContext GetEnemyUserContextByMyCard(this GameContext context, Card myCard)
        {
            if (context.AllCard.Any(c => c.CardInGameCode == myCard.CardInGameCode))
            {
                if (context.Players[0].AllCards.Any(c => c.CardInGameCode == myCard.CardInGameCode))
                    return context.Players[0];
                return context.Players[1];
            }
            return null;
        }

        /// <summary>
        /// 移除（沉默、BUFF时间过期）卡牌技能
        /// </summary>
        /// <param name="lstCard"></param>
        /// <param name="cl"></param>
        /// <param name="spellTime"></param>
        public static void DisableCardAbility(this GameContext context, IEnumerable<Card> lstCard, CardLocation cl, BuffTimeLimit buffTime)
        {
            var lstCards = lstCard.Where(c => c != null && c.CardLocation == cl);
            if (lstCards != null)
            {
                foreach (Card card in lstCards)
                {
                    //foreach (var buff in card.Buffs.Where(c => c.Value.BuffTime == buffTime))
                    //{
                    //    buff.Value.CastAbility(context, null, card, -1);
                    //}
                    //card.Buffs.Clear();
                    card.Abilities.Clear();
                }
            }
        }

        /// <summary>
        /// 从牌库里抽牌
        /// </summary>
        /// <param name="context"></param>
        /// <param name="isActivation"></param>
        /// <param name="drawCount"></param>
        public static void DrawCard(this GameContext context, bool isActivation = true, int drawCount = 1)
        {
            UserContext uc = null;
            if (isActivation)
            {
                uc = context.GetActivationUserContext();
            }
            else
            {
                uc = context.GetNotActivationUserContext();
            }
            for (int i = 1; i <= drawCount; i++)
            {
                ///当牌库里有牌时
                if (uc.StockCards.Count > 0)
                {
                    var drawCard = uc.StockCards.First();
                    if (uc.HandCards.Count < 10)
                    {
                        //如果手牌没满则放入手牌中
                        uc.HandCards.Add(drawCard);
                        drawCard.CardLocation = CardLocation.手牌;
                    }
                    else
                    {
                        //否则撕了这张牌
                        drawCard.CardLocation = CardLocation.坟场;
                        uc.GraveyardCards.Add(drawCard);
                    }
                    //最后从牌库移除这张牌
                    uc.StockCards.RemoveAt(0);
                }
                else
                {
                    //没牌则计算疲劳值
                    uc.FatigueValue++;
                    int trueDamege = uc.FatigueValue;
                    if (uc.Hero.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方英雄受到伤害)))
                    {
                        context.TriggerCardAbility(uc.DeskCards, CardLocation.场上, SpellCardAbilityTime.己方英雄受到伤害);
                    }
                    else
                    {
                        if (trueDamege >= uc.Hero.Ammo)
                        {
                            trueDamege -= uc.Hero.Ammo;
                            uc.Hero.Ammo = 0;
                        }
                        else
                        {
                            uc.Hero.Ammo -= trueDamege;
                            trueDamege = 0;
                        }
                        uc.Hero.Life -= trueDamege;
                    }
                }
            }
        }

        /// <summary>
        /// 随从、英雄受到伤害（被火球砸、火冲点）
        /// </summary>
        /// <param name="triggerCard"></param>
        /// <param name="location"></param>
        /// <param name="target"></param>
        public static void BiologyByDamege(this GameContext context, Card sourceCard, int damege, int target)
        {
            BaseBiology targetBiology = context.GetCardByLocation(target) as BaseBiology;
            if (targetBiology != null)
            {
                int trueDamege = damege;
                if (targetBiology is BaseHero)
                {
                    BaseHero hero = context.GetCardByLocation(target) as BaseHero;
                    if (hero.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.对方英雄受到伤害)))
                    {
                        TriggerCardAbility(context, new List<Card>() { hero }, CardLocation.场上, SpellCardAbilityTime.对方英雄受到伤害, sourceCard, target);
                    }
                    else
                    {
                        if (trueDamege >= hero.Ammo)
                        {
                            trueDamege -= hero.Ammo;
                            hero.Ammo = 0;
                        }
                        else
                        {
                            hero.Ammo -= trueDamege;
                            trueDamege = 0;
                        }
                        hero.Life -= trueDamege;
                    }
                }
                else
                {
                    if (targetBiology.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方随从受到伤害)))
                    {
                        TriggerCardAbility(context, new List<Card>() { targetBiology }, CardLocation.场上, SpellCardAbilityTime.己方随从受到伤害, sourceCard, target);
                    }
                    else
                    {
                        targetBiology.Life -= trueDamege;
                    }
                    //随从死亡
                    if (targetBiology.Life < 1)
                    {
                        //随从进坟场
                        targetBiology.CardLocation = CardLocation.坟场;
                        UserContext enemy = context.GetNotActivationUserContext();
                        enemy.GraveyardCards.Add(targetBiology);

                        TriggerCardAbility(context, context.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从入坟场, sourceCard, target);
                        TriggerCardAbility(context, context.GetNotActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方随从入坟场, sourceCard, target);
                    }
                }
            }
        }


        /// <summary>
        /// 触发卡牌技能
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="spellTime"></param>
        /// <param name="triggerCard"></param>
        /// <param name="target"></param>
        public static void TriggerCardAbility(this GameContext context, IEnumerable<Card> lstCard, CardLocation cl, SpellCardAbilityTime spellTime, Card triggerCard = null, int target = -1)
        {
            if (lstCard != null && lstCard.Any(c => c != null && c.CardLocation == cl))
            {
                var lstCards = lstCard.Where(c => c != null && c.CardLocation == cl).ToList();
                for (int i = 0; i < lstCards.Count(); i++)
                {
                    if (lstCards[i].Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == spellTime)))
                    {
                        for (int n = 0; n < lstCards[i].Abilities.Where(c => c.LstSpellCardAbilityTime.Any(x => x == spellTime)).ToList().Count; n++)
                        {
                            lstCards[i].Abilities[n].CastAbility(context, triggerCard, lstCards[i], target);
                        }
                    }
                    //if (lstCards[i].Buffs.Any(c => c.Value.LstSpellCardAbilityTime.Any(x => x == spellTime)))
                    //{
                    //    for (int n = 0; n < lstCards[i].Buffs.Where(c => c.Value.LstSpellCardAbilityTime.Any(x => x == spellTime)).ToList().Count; n++)
                    //    {
                    //        lstCards[i].Abilities[n].CastAbility(context, triggerCard, lstCards[i], target);
                    //    }
                    //}
                }
            }
        }
    }
}
