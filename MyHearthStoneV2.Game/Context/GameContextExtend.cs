using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Context
{
    /// <summary>
    /// 游戏环境扩展类
    /// </summary>
    internal static class GameContextExtend
    {
        internal static GameContextOutput Output(this GameContext gameContext, string userCode)
        {
            GameContextOutput gameContextOutput = new GameContextOutput()
            {
                GameCode = gameContext.GameCode,
                TurnIndex = gameContext.TurnIndex,
                CastCardCount = gameContext.CastCardCount,
                CurrentTurnCode = gameContext.CurrentTurnCode,
                CurrentTurnRemainingSecond = gameContext.CurrentTurnRemainingSecond,
                DeskCards = gameContext.DeskCards,
                NextTurnCode = gameContext.NextTurnCode,
            };

            foreach (var cd in gameContext.Players)
            {
                if (userCode == cd.UserCode)
                {
                    gameContextOutput.Players.Add(new UserContextOutput()
                    {
                        HandCards = cd.HandCards,
                        InitCards = cd.InitCards,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode,
                        TurnIndex = gameContext.TurnIndex,
                        FullPower = cd.FullPower,
                        Hero = gameContext.GetHeroByActivation(cd.IsActivation),
                    });
                }
                else
                {
                    gameContextOutput.Players.Add(new UserContextSimpleOutput()
                    {
                        HandCards = cd.HandCards.Count,
                        InitCards = cd.InitCards.Count,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode,
                        TurnIndex = gameContext.TurnIndex,
                        FullPower = cd.FullPower,
                        Hero = gameContext.GetHeroByActivation(cd.IsActivation),
                    });
                }
            }
            return gameContextOutput;
        }

        internal static GameContextOutput Output(this GameContext gameContext)
        {
            GameContextOutput gameContextOutput = new GameContextOutput()
            {
                GameCode = gameContext.GameCode,
                TurnIndex = gameContext.TurnIndex,
                CastCardCount = gameContext.CastCardCount,
                CurrentTurnCode = gameContext.CurrentTurnCode,
                CurrentTurnRemainingSecond = gameContext.CurrentTurnRemainingSecond,
                DeskCards = gameContext.DeskCards,
                NextTurnCode = gameContext.NextTurnCode,
            };
            foreach (var cd in gameContext.Players)
            {
                if (cd.IsActivation)
                {
                    gameContextOutput.Players.Add(new UserContextOutput()
                    {
                        HandCards = cd.HandCards,
                        InitCards = cd.InitCards,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode,
                        TurnIndex = gameContext.TurnIndex,
                        FullPower = cd.FullPower,
                        Hero = gameContext.GetHeroByActivation(cd.IsActivation),
                    });
                }
                else
                {
                    gameContextOutput.Players.Add(new UserContextSimpleOutput()
                    {
                        HandCards = cd.HandCards.Count,
                        InitCards = cd.InitCards.Count,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode,
                        TurnIndex = gameContext.TurnIndex,
                        FullPower = cd.FullPower,
                        Hero = gameContext.GetHeroByActivation(cd.IsActivation),
                    });
                }
            }
            return gameContextOutput;
        }

        /// <summary>
        /// 阶段检索，即在每一个结算队列结算完之后，开始的检索，包括死亡检索、受伤检索，光环检索等
        /// </summary>
        /// <param name="context"></param>
        internal static void StageRetrieval(this GameContext context)
        {
            if (context.DeskCards.Any(c => c != null && c.Life < 1))
            {
                //先按入场顺序排列
                var lstBiology = context.DeskCards.Where(c => c != null && c.Life < 1).OrderBy(x => x.CastIndex);
                foreach (var bio in lstBiology)
                {
                    BaseActionParameter para = CardActionFactory.CreateParameter(bio, context);
                    CardActionFactory.CreateAction(bio, ActionType.死亡).Action(para);
                    //bio.BiologyDead(context, null);
                }
                QueueSettlement(context);
            }
        }

        /// <summary>
        /// 进行队列结算
        /// </summary>
        /// <param name="context"></param>
        internal static void QueueSettlement(this GameContext context)
        {
            LinkedList<ActionStatement> ll = context.ActionStatementQueue;
            if (ll != null && ll.Count > 0)
            {
                LinkedListNode<ActionStatement> node = ll.First;
                while (node != null)
                {
                    node.Value.Settlement();
                    node = node.Next;
                }
                ll.Clear();                
            }
            StageRetrieval(context);
        }

        /// <summary>
        /// 添加一个结算队列
        /// </summary>
        /// <param name="context"></param>
        /// <param name="lstCard"></param>
        /// <param name="cl"></param>
        /// <param name="triggerCard"></param>
        /// <param name="target"></param>
        //internal static void AddActionStatement(this GameContext context, IEnumerable<Card> lstCard, Card triggerCard = null, int target = -1)
        //{
        //    var lstCards = lstCard.Where(c => c != null).OrderBy(c => c.CastIndex).ToList();
        //    for (int i = 0; i < lstCards.Count(); i++)
        //    {
        //        AddActionStatement(context, lstCards[i], triggerCard, target);
        //    }
        //}

        /// <summary>
        /// 添加一个卡牌技能触发到结算队列
        /// </summary>
        /// <param name="context"></param>
        /// <param name="card"></param>
        /// <param name="triggerCard"></param>
        /// <param name="target"></param>
        internal static void AddActionStatement(this GameContext context, IGameAction gameAction, BaseActionParameter actionParameter)
        {
            ActionStatement statement = new ActionStatement()
            {
                CardActionParameter = actionParameter,
                GameAction = gameAction,
            };
            context.ActionStatementQueue.AddLast(statement);
        }

        /// <summary>
        /// 创造一张牌到场内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="isActivation">是否是当前回合玩家的牌</param>
        /// <returns></returns>
        //internal static T CreateNewCardInDesk<T>(this GameContext context, bool isActivation = true) where T : BaseServant
        //{
        //    T servant = Activator.CreateInstance<T>();
        //    string cardCode = "";
        //    using (var redisClient = RedisManager.GetClient())
        //    {
        //        List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
        //        cardCode = lstCardLib.First(c => c.GetType() == typeof(T)).CardCode;
        //    }
        //    servant.CardCode = cardCode;
            
        //    var player = context.Players.First(c => c.IsActivation == isActivation);
        //    int deskIndex = 0;
        //    int searchCount = 0;
        //    for (int i = player.IsFirst ? 0 : 8; i < context.DeskCards.Count; i++)
        //    {
        //        searchCount++;
        //        if (searchCount > 8)
        //        {
        //            break;
        //        }
        //        if (context.DeskCards[i] == null)
        //        {
        //            deskIndex = i;
        //            break;
        //        }
        //    }
            
        //    context.AllCard.Add(servant);
        //    servant.DeskIndex = deskIndex;
        //    servant.CardInGameCode = context.AllCard.Count.ToString();
        //    context.DeskCards[deskIndex] = servant;
        //    player.AllCards.Add(servant);
        //    servant.Cast(context, deskIndex, -1);            

        //    context.TriggerCardAbility(context.DeskCards.GetDeskCardsByMyCard(servant), SpellCardAbilityTime.己方随从入场, servant);
        //    var playerTwo = context.Players.First(c => c.IsActivation != isActivation);
        //    context.TriggerCardAbility(context.DeskCards.GetDeskCardsByEnemyCard(servant), SpellCardAbilityTime.对方随从入场, servant);
        //    return servant;
        //}

        /// <summary>
        /// 创造一张牌到游戏中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        //internal static T CreateNewCardInController<T>(this GameContext context, UserContext userContext) where T : Card
        //{
        //    T card = Activator.CreateInstance<T>();
        //    string cardCode = "";
        //    using (var redisClient = RedisManager.GetClient())
        //    {
        //        List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
        //        cardCode = lstCardLib.First(c => c.GetType() == typeof(T)).CardCode;
        //    }
        //    card.CardCode = cardCode;
        //    context.AllCard.Add(card);
        //    card.CardInGameCode = context.AllCard.Count.ToString();
        //    context.Players.First(c => c == userContext).AllCards.Add(card);
        //    return card;
        //}

        /// <summary>
        /// 获取当前回合玩家
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        internal static UserContext GetActivationUserContext(this GameContext context)
        {
            return context.Players.First(c => c.IsActivation);
        }

        /// <summary>
        /// 获取不是当前回合的玩家
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        internal static UserContext GetNotActivationUserContext(this GameContext context)
        {
            if (context.Players.Any(c => c.IsActivation == false))
                return context.Players.First(c => c.IsActivation == false);
            return context.Players.First(c => c.IsFirst == false);
        }

        /// <summary>
        /// 判断这张牌是否是当前回合玩家打出的牌
        /// </summary>
        /// <param name="context"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        internal static bool IsThisActivationUserCard(this GameContext context, Card card)
        {
            return context.Players.Any(c => c.IsActivation && c.AllCards.Any(x => x.CardInGameCode == card.CardInGameCode));
        }

        internal static bool IsThisActivationUserCard(this GameContext context, List<Card> cards)
        {
            return context.Players.Any(c => c.IsActivation && c.AllCards.Any(x => cards.Any(n => n.CardInGameCode == x.CardInGameCode)));
        }

        /// <summary>
        /// 根据自己的牌获取敌方的用户环境对象
        /// </summary>
        /// <param name="context"></param>
        /// <param name="myCard"></param>
        /// <returns></returns>
        internal static UserContext GetEnemyUserContextByMyCard(this GameContext context, Card myCard)
        {
            if (context.AllCard.Any(c => c.CardInGameCode == myCard.CardInGameCode))
            {
                if (context.Players[0].AllCards.Any(c => c.CardInGameCode == myCard.CardInGameCode))
                    return context.Players[1];
                return context.Players[0];
            }
            return null;
        }

        /// <summary>
        /// 根据自己的牌获取自己的用户环境对象
        /// </summary>
        /// <param name="context"></param>
        /// <param name="myCard"></param>
        /// <returns></returns>
        internal static UserContext GetUserContextByMyCard(this GameContext context, Card myCard)
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
        /// 根据敌方的牌获取自己的用户环境对象
        /// </summary>
        /// <param name="context"></param>
        /// <param name="enemyCard"></param>
        /// <returns></returns>
        internal static UserContext GetUserContextByEnemyCard(this GameContext context, Card enemyCard)
        {
            if (context.AllCard.Any(c => c.CardInGameCode == enemyCard.CardInGameCode))
            {
                if (context.Players[0].AllCards.Any(c => c.CardInGameCode == enemyCard.CardInGameCode))
                    return context.Players[1];
                return context.Players[0];
            }
            return null;
        }



        internal static BaseHero GetHeroByActivation(this GameContext gameContext, bool isActivation = true)
        {
            return gameContext.DeskCards.GetHeroByIsFirst(gameContext.Players.First(c => c.IsActivation == isActivation).IsFirst);
        }


        /// <summary>
        /// 从牌库里抽牌
        /// </summary>
        /// <param name="context"></param>
        /// <param name="isActivation"></param>
        /// <param name="drawCount"></param>
        //internal static void DrawCard(this GameContext context, bool isActivation = true, int drawCount = 1)
        //{
        //    UserContext uc = null;
        //    if (isActivation)
        //    {
        //        uc = context.GetActivationUserContext();
        //    }
        //    else
        //    {
        //        uc = context.GetNotActivationUserContext();
        //    }
        //    BaseHero hero = context.GetHeroByActivation(uc.IsActivation);
        //    for (int i = 1; i <= drawCount; i++)
        //    {
        //        //当牌库里有牌时
        //        if (uc.StockCards.Count > 0)
        //        {
        //            var drawCard = uc.StockCards.First();
        //            if (uc.HandCards.Count < 10)
        //            {
        //                //如果手牌没满则放入手牌中
        //                uc.HandCards.Add(drawCard);
        //                drawCard.CardLocation = CardLocation.手牌;
        //            }
        //            else
        //            {
        //                //否则撕了这张牌
        //                drawCard.CardLocation = CardLocation.坟场;
        //                uc.GraveyardCards.Add(drawCard);
        //            }
        //            //最后从牌库移除这张牌
        //            uc.StockCards.RemoveAt(0);
        //        }
        //        else
        //        {
        //            //没牌则计算疲劳值
        //            uc.FatigueValue++;
        //            int trueDamege = uc.FatigueValue;
        //            if (hero.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄受到伤害前)))
        //            {
        //                context.TriggerCardAbility(context.DeskCards.GetDeskCardsByIsFirst(context.Players.First(c => c.IsActivation == isActivation).IsFirst), SpellCardAbilityTime.己方英雄受到伤害前);
        //            }
        //            else
        //            {
        //                if (trueDamege >= hero.Ammo)
        //                {
        //                    trueDamege -= hero.Ammo;
        //                    hero.Ammo = 0;
        //                }
        //                else
        //                {
        //                    hero.Ammo -= trueDamege;
        //                    trueDamege = 0;
        //                }
        //                hero.Life -= trueDamege;
        //            }
        //            context.TriggerCardAbility(new List<Card>() { hero }, SpellCardAbilityTime.己方英雄受到伤害后);
        //        }
        //    }
        //}

        /// <summary>
        /// 移除（沉默、BUFF时间过期）卡牌技能
        /// </summary>
        /// <param name="lstCard"></param>
        /// <param name="cl"></param>
        /// <param name="spellTime"></param>
        internal static void DisableCardAbility(this GameContext context, IEnumerable<BaseBiology> lstCard)
        {
            foreach (BaseBiology card in lstCard)
            {
                card.Damage = card.InitialDamage;
                card.Cost = card.InitialCost;
                card.Life = card.InitialLife;
                card.Abilities.Clear();
            }
        }


        /// <summary>
        /// 触发卡牌技能
        /// </summary>
        /// <param name="context"></param>
        /// <param name="card"></param>
        /// <param name="spellTime"></param>
        /// <param name="triggerCard"></param>
        /// <param name="target"></param>
        internal static void TriggerCardAbility(this GameContext context, Card card, SpellCardAbilityTime spellTime, Card triggerCard = null, int target = -1)
        {
            var triggerAbilities = card.Abilities.Where(c => c.SpellCardAbilityTimes.Any(x => x == spellTime)).ToList();
            for (int n = 0; n < triggerAbilities.Count; n++)
            {
                BaseCardAbility ca = card.Abilities.First(c => c == triggerAbilities[n]);
                CardAbilityParameter para = new CardAbilityParameter()
                {
                    GameContext = context,
                    MainCard = card,
                    SecondaryCard = triggerCard,
                    MainCardLocation = target,
                };

                AddActionStatement(context, ca, para);
                //lstCards[i].Abilities.First(c => c == triggerAbilities[n]).CastAbility(context, triggerCard, lstCards[i], target);
            }
        }

        /// <summary>
        /// 触发卡牌技能
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="spellTime"></param>
        /// <param name="triggerCard"></param>
        /// <param name="target"></param>
        internal static void TriggerCardAbility(this GameContext context, IEnumerable<Card> lstCard, SpellCardAbilityTime spellTime, Card triggerCard = null, int target = -1)
        {
            if (lstCard == null || !lstCard.Any(c => c != null)) return;
            var lstCards = lstCard.Where(c => c != null).OrderBy(c => c.CastIndex).ToList();
            for (int i = 0; i < lstCards.Count(); i++)
            {
                if (!lstCards[i].Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == spellTime))) continue;
                TriggerCardAbility(context, lstCards[i], spellTime, triggerCard, target);                
            }
        }

        /// <summary>
        /// 触发卡牌技能
        /// </summary>
        /// <param name="context"></param>
        /// <param name="lstCard"></param>
        /// <param name="abilityType"></param>
        /// <param name="triggerCard"></param>
        /// <param name="target"></param>
        internal static void TriggerCardAbility(this GameContext context, IEnumerable<Card> lstCard, AbilityType abilityType, Card triggerCard = null, int target = -1)
        {
            if (lstCard == null || !lstCard.Any(c => c != null)) return;
            var lstCards = lstCard.Where(c => c != null).OrderBy(c => c.CastIndex).ToList();
            for (int i = 0; i < lstCards.Count(); i++)
            {
                if (!lstCards[i].Abilities.Any(c => c.AbilityType == abilityType)) continue;
                BaseCardAbility ca = lstCards[i].Abilities.First(c => c.AbilityType == abilityType);
                CardAbilityParameter para = new CardAbilityParameter()
                {
                    GameContext = context,
                    MainCard = lstCards[i],
                    SecondaryCard = triggerCard,
                    MainCardLocation = target,
                };

                AddActionStatement(context, ca, para);
            }
        }
    }
}
