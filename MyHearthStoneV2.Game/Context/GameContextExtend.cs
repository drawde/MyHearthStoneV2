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
using MyHearthStoneV2.Game.Event;

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
        /// 阶段检索，即在每一个结算队列结算完之后，开始的检索，包括死亡检索、受伤检索等
        /// </summary>
        /// <param name="context"></param>
        internal static void StageRetrieval(this GameContext context)
        {
            if (context.DeskCards.Any(c => c != null && c.Life < 1))
            {
                //先按入场顺序排列
                var lstBiology = context.DeskCards.Where(c => c != null && (c.Life < 1 || c.Deathing)).OrderBy(x => x.CastIndex);
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
        /// 进行队列结算、光环更新
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
            AuraSettlement(context);
            StageRetrieval(context);
        }

        /// <summary>
        /// 光环结算
        /// </summary>
        /// <param name="context"></param>
        internal static void AuraSettlement(this GameContext context)
        {
            //先移除光环BUFF
            foreach (BaseBiology biology in context.DeskCards.Where(c => c != null && c.Abilities.Any(x => x.AbilityType == AbilityType.光环BUFF)))
            {
                foreach (BaseCardAbility ability in biology.Abilities.Where(x => x.AbilityType == AbilityType.光环BUFF))
                {
                    CardAbilityParameter para = new CardAbilityParameter()
                    {
                        GameContext = context,
                        MainCard = biology,
                    };
                    ability.Action(para);
                    //biology.Abilities.Remove(ability);
                }
                biology.Abilities.RemoveAll(x => x.AbilityType == AbilityType.光环BUFF);
            }

            //再重新触发光环效果（不会触发有触发条件的随从如索瑞森大帝）
            foreach (BaseBiology biology in context.DeskCards.Where(c => c != null && c.Abilities.Any(x => x.AbilityType == AbilityType.光环)))
            {
                foreach (BaseCardAbility ability in biology.Abilities.Where(x => x.AbilityType == AbilityType.光环 && x.SpellCardAbilityTimes.Count == 0))
                {
                    CardAbilityParameter para = new CardAbilityParameter()
                    {
                        GameContext = context,
                        MainCard = biology,
                    };
                    ability.Action(para);
                }
            }
        }

        /// <summary>
        /// 随从移位
        /// </summary>
        /// <param name="gameContext"></param>
        /// <param name="deskIndex"></param>
        internal static int ShiftServant(this GameContext gameContext, int deskIndex)
        {
            if (gameContext.DeskCards[deskIndex] != null)
            {
                bool shiftDone = false;
                int maxIndex = 16,minIndex = 8;
                if (deskIndex < 8)
                {
                    maxIndex = 8;
                    minIndex = 0;
                }
                #region 先往右移
                int idx = deskIndex + 1;
                for (; idx < maxIndex; idx++)
                {
                    if (gameContext.DeskCards[idx] == null)
                    {                        
                        BaseServant servant = null;
                        for (int i = idx; i > deskIndex; i--)
                        {
                            servant = gameContext.DeskCards[i - 1] as BaseServant;
                            servant.DeskIndex = i;
                            gameContext.DeskCards[i] = servant;
                            gameContext.DeskCards[i - 1] = null;
                        }
                        shiftDone = true;
                        break;
                    }
                }
                #endregion

                #region 右移失败再尝试左移
                if (shiftDone == false)
                {
                    idx = deskIndex - 1;
                    for (; idx > minIndex; idx--)
                    {
                        if (gameContext.DeskCards[idx] == null)
                        {
                            BaseServant servant = null;
                            //for (int i = 2; i < 4; i++)
                            for (int i = idx; i < deskIndex - 1; i++)
                            {
                                servant = gameContext.DeskCards[i + 1] as BaseServant;
                                servant.DeskIndex = i;
                                gameContext.DeskCards[i] = servant;
                            }
                            shiftDone = true;
                            deskIndex = deskIndex - 1;
                            break;
                        }
                    }
                }
                #endregion                
            }
            return deskIndex;
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

        internal static void EventQueueSettlement(this GameContext context)
        {
            LinkedList<IEvent> ll = context.EventQueue;
            if (ll != null && ll.Count > 0)
            {
                LinkedListNode<IEvent> node = ll.First;
                while (node != null)
                {
                    node.Value.Settlement();
                    //foreach(Card card in context.AllCard.Where(c=>c.Abilities.Any(x=>x.)))
                    node = node.Next;
                }
                ll.Clear();
            }
        }

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
            else if (context.DeskCards.GetFirstPlayerHero().CardInGameCode == myCard.CardInGameCode)
            {
                return context.Players.First(c => c.IsFirst);
            }
            else if (context.DeskCards.GetSecondPlayerHero().CardInGameCode == myCard.CardInGameCode)
            {
                return context.Players.First(c => c.IsFirst == false);
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
        /// 触发卡牌技能
        /// </summary>
        /// <param name="context"></param>
        /// <param name="card"></param>
        /// <param name="spellTime"></param>
        /// <param name="triggerCard"></param>
        /// <param name="target"></param>
        internal static void TriggerCardAbility(this GameContext context, Card card, SpellCardAbilityTime spellTime, AbilityType abilityType = AbilityType.无, Card triggerCard = null, int target = -1)
        {
            var triggerAbilities = card.Abilities.Where(c => c.SpellCardAbilityTimes.Any(x => x == spellTime) && c.AbilityType == abilityType).ToList();
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
                TriggerCardAbility(context, lstCards[i], spellTime, AbilityType.无, triggerCard, target);                
            }
        }

        internal static void TriggerCardAbility(this GameContext context, IEnumerable<Card> lstCard, SpellCardAbilityTime spellTime, AbilityType abilityType, Card triggerCard = null, int target = -1)
        {
            if (lstCard == null || !lstCard.Any(c => c != null)) return;
            var lstCards = lstCard.Where(c => c != null).OrderBy(c => c.CastIndex).ToList();
            for (int i = 0; i < lstCards.Count(); i++)
            {
                if (!lstCards[i].Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == spellTime) && c.AbilityType == abilityType)) continue;
                TriggerCardAbility(context, lstCards[i], spellTime, abilityType, triggerCard, target);
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
