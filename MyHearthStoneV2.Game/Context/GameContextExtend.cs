﻿using MyHearthStoneV2.Game.CardLibrary;
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
using MyHearthStoneV2.Game.Event.Player;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.Parameter.Equip;

namespace MyHearthStoneV2.Game.Context
{
    /// <summary>
    /// 游戏环境扩展类
    /// </summary>
    public static class GameContextExtend
    {
        public static GameContextOutput Output(this GameContext gameContext, string userCode)
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

        public static GameContextOutput Output(this GameContext gameContext)
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
        public static void StageRetrieval(this GameContext context)
        {
            bool hasQueueSettlement = false;
            if (context.DeskCards.Any(c => c != null && c.Life < 1))
            {
                //先按入场顺序排列
                var lstBiology = context.DeskCards.Where(c => c != null && (c.Life < 1 || c.IsDeathing)).OrderBy(x => x.CastIndex);
                foreach (var bio in lstBiology)
                {
                    BaseActionParameter para = CardActionFactory.CreateParameter(bio, context);
                    CardActionFactory.CreateAction(bio, ActionType.死亡).Action(para);
                    //bio.BiologyDead(context, null);
                }
                hasQueueSettlement = true;
            }
            if (context.DeskCards.Any(c => c != null && c.CardType == CardType.英雄 && (c as BaseHero).Equip != null && (c as BaseHero).Equip.Durable < 1))
            {
                var heros = context.DeskCards.Where(c => c != null && c.CardType == CardType.英雄 && (c as BaseHero).Equip != null && (c as BaseHero).Equip.Durable < 1);
                foreach (var hero in heros)
                {
                    UnloadAction unloadAction = new UnloadAction();
                    EquipActionParameter equipPara = new EquipActionParameter()
                    {
                        GameContext = context,
                        Equip = (hero as BaseHero).Equip,
                    };
                    unloadAction.Action(equipPara);
                }
                hasQueueSettlement = true;
            }
            if (hasQueueSettlement) QueueSettlement(context);
        }

        /// <summary>
        /// 进行队列结算、光环更新
        /// </summary>
        /// <param name="context"></param>
        public static void QueueSettlement(this GameContext context)
        {
            EventQueueSettlement(context);
            LinkedList<ActionStatement> ll = context.ActionStatementQueue;
            if (ll != null && ll.Count > 0)
            {
                LinkedListNode<ActionStatement> node = ll.First;
                while (node != null)
                {
                    node.Value.Settlement();
                    node = node.Next;
                    Card deadCard = node.Value.CardActionParameter.MainCard;
                    if (deadCard != null && context.HearseCards.Any(c=>c.CardInGameCode == deadCard.CardInGameCode))
                    {
                        UserContext uc = context.GetUserContextByMyCard(deadCard);
                        //进坟场
                        deadCard.CardLocation = CardLocation.坟场;
                        uc.GraveyardCards.Add(deadCard);
                        context.HearseCards.Remove(deadCard);
                    }
                }
                ll.Clear();
            }
            ClearHearse(context);
            AutoShiftServant(context);
            AuraSettlement(context);
            StageRetrieval(context);
        }

        public static void ClearHearse(this GameContext context)
        {
            LinkedList<Card> ll = context.HearseCards;
            if (ll != null && ll.Count > 0)
            {
                LinkedListNode<Card> node = ll.First;
                while (node != null)
                {
                    UserContext uc = context.GetUserContextByMyCard(node.Value);
                    node.Value.CardLocation = CardLocation.坟场;
                    uc.GraveyardCards.Add(node.Value);
                    node = node.Next;
                }
                ll.Clear();
            }
        }

        public static void EventQueueSettlement(this GameContext context)
        {
            AddEndOfPlayerActionEvent(context);
            LinkedList<IEvent> ll = context.EventQueue;
            if (ll != null && ll.Count > 0)
            {
                LinkedListNode<IEvent> node = ll.First;
                while (node != null)
                {
                    node.Value.Settlement();
                    node = node.Next;
                }
                ll.Clear();
            }
        }
        public static void AddEndOfPlayerActionEvent(this GameContext context)
        {
            foreach (Card card in context.AllCard)
            {
                CardAbilityParameter para = new CardAbilityParameter()
                {
                    MainCard = card,
                    GameContext = context
                };
                context.EventQueue.AddLast(new EndOfPlayerActionEvent() { EventCard = card, Parameter = para });
            }
        }
        /// <summary>
        /// 光环结算
        /// </summary>
        /// <param name="context"></param>
        public static void AuraSettlement(this GameContext context)
        {
            LinkedList<IAura> ll = context.Aurae;
            if (ll != null && ll.Count > 0)
            {
                LinkedListNode<IAura> node = ll.First;
                while (node != null)
                {
                    CardAbilityParameter para = new CardAbilityParameter()
                    {
                        MainCard = node.Value.AuraCard,
                        GameContext = context
                    };

                    node.Value.RestoreAura(para);
                    node.Value.Action(para);
                    node = node.Next;
                }
                ll.Clear();
            }
        }

        /// <summary>
        /// 把随从自动向中间靠拢
        /// </summary>
        /// <param name="gameContext"></param>
        /// <param name="deskIndex"></param>
        /// <returns></returns>
        public static int AutoShiftServant(this GameContext gameContext, int deskIndex)
        {
            if (deskIndex < 4 && gameContext.DeskCards[deskIndex + 1] == null)
            {
                return AutoShiftServant(gameContext, deskIndex + 1);
            }
            else if (deskIndex > 4 && deskIndex < 8 && gameContext.DeskCards[deskIndex - 1] == null)
            {
                return AutoShiftServant(gameContext, deskIndex - 1);
            }
            else if (deskIndex < 12 && deskIndex > 8 && gameContext.DeskCards[deskIndex + 1] == null)
            {
                return AutoShiftServant(gameContext, deskIndex + 1);
            }
            else if (deskIndex > 12 && gameContext.DeskCards[deskIndex - 1] == null)
            {
                return AutoShiftServant(gameContext, deskIndex - 1);
            }
            return deskIndex;
        }

        /// <summary>
        /// 把随从自动向中间靠拢
        /// </summary>
        /// <param name="gameContext"></param>
        public static void AutoShiftServant(this GameContext gameContext)
        {
            int centerIndex = 4, minIndex = 0, maxIndex = 8;
            for (int t = 0; t < 2; t++)
            {
                List<BaseBiology> lstRight = gameContext.DeskCards.Where(c => c != null && c.DeskIndex >= centerIndex && c.DeskIndex < maxIndex).ToList();
                int idx = 0;
                for (int i = centerIndex; i < maxIndex; i++)
                {
                    gameContext.DeskCards[i] = null;
                    if (lstRight.Count > idx)
                    {
                        gameContext.DeskCards[i] = lstRight[idx];
                    }
                    idx++;
                }

                List<BaseBiology> lstLeft = gameContext.DeskCards.Where(c => c != null && c.DeskIndex > minIndex && c.DeskIndex < centerIndex).ToList();
                idx = 0;
                for (int i = centerIndex - 1; i > minIndex; i--)
                {
                    gameContext.DeskCards[i] = null;
                    if (lstLeft.Count > idx)
                    {
                        gameContext.DeskCards[i] = lstLeft[idx];
                    }
                    idx++;
                }

                minIndex += 8;
                maxIndex += 8;
                centerIndex += 8;
            }
        }

        /// <summary>
        /// 随从移位
        /// </summary>
        /// <param name="gameContext"></param>
        /// <param name="deskIndex"></param>
        public static int ShiftServant(this GameContext gameContext, int deskIndex)
        {
            if (gameContext.DeskCards[deskIndex] != null)
            {
                bool shiftDone = false;
                int maxIndex = 16, minIndex = 8;
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
        /// 添加一个卡牌技能触发到结算队列
        /// </summary>
        /// <param name="context"></param>
        /// <param name="card"></param>
        /// <param name="triggerCard"></param>
        /// <param name="target"></param>
        public static void AddActionStatement(this GameContext context, IGameAction gameAction, BaseActionParameter actionParameter)
        {
            ActionStatement statement = new ActionStatement()
            {
                CardActionParameter = actionParameter,
                GameAction = gameAction,
            };
            context.ActionStatementQueue.AddLast(statement);
        }

        public static void AddActionStatements(this GameContext context, IEnumerable<IGameAction> IGameActions, BaseActionParameter actionParameter)
        {
            foreach (var gameAction in IGameActions)
            {
                AddActionStatement(context, gameAction, actionParameter);
            }
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
        /// <param name="card"></param>
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
        public static UserContext GetUserContextByMyCard(this GameContext context, Card myCard)
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
        public static UserContext GetUserContextByEnemyCard(this GameContext context, Card enemyCard)
        {
            if (context.AllCard.Any(c => c.CardInGameCode == enemyCard.CardInGameCode))
            {
                if (context.Players[0].AllCards.Any(c => c.CardInGameCode == enemyCard.CardInGameCode))
                    return context.Players[1];
                return context.Players[0];
            }
            return null;
        }



        public static BaseHero GetHeroByActivation(this GameContext gameContext, bool isActivation = true)
        {
            return gameContext.DeskCards.GetHeroByIsFirst(gameContext.Players.First(c => c.IsActivation == isActivation).IsFirst);
        }        
    }
}
