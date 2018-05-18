﻿using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.GameProcess;
using MyHearthStoneV2.Game.Monitor;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.ShortCodeBll;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Log;
using Newtonsoft.Json;

namespace MyHearthStoneV2.Game.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 回合结束
        /// </summary>                
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98)]
        public void TurnEnd()
        {
            UserContext uc = GameContext.GetActivationUserContext(), next_uc = null;

            List<Card> buffCards = new List<Card>();
            buffCards.AddRange(GameContext.DeskCards.GetDeskCardsByIsFirst(uc.IsFirst));
            buffCards.AddRange(uc.HandCards);
            buffCards = buffCards.Where(c => c.Buffs.Count > 0).ToList();
            foreach (Card card in buffCards)
            {
                LinkedListNode<IBuffRestore<ICardLocationFilter, IEvent>> buff = card.Buffs.First;
                while (buff != null)
                {
                    buff.Value.Action(new CardAbilityParameter()
                    {
                        GameContext = GameContext,
                        PrimaryCard = card
                    });
                }
            }

            GameContext.TurnIndex++;
            #region 调整玩家对象
            if (GameContext.TurnIndex > 0)
            {
                next_uc = GameContext.GetNotActivationUserContext();

                CardAbilityParameter para = new CardAbilityParameter()
                {
                    GameContext = GameContext
                };
                GameContext.EventQueue.AddLast(new MyTurnEndEvent() { Parameter = para });
                foreach (var bio in GameContext.DeskCards.Where(c => c != null))
                {
                    BaseBiology biology = bio as BaseBiology;
                    biology.RemainAttackTimes = 0;
                }

                //在回合交换前结算
                GameContext.QueueSettlement();
                GameContextCache.SetContext(GameContext);
                DataExchangeBll.Instance.AsyncInsert("TurnEnd", "Controler_Base", "", JsonConvert.SerializeObject(GameContext), DataSourceEnum.GameControler);
                
                uc.IsActivation = false;
                next_uc.IsActivation = true;
                
            }
            else
            {
                //开局换完牌后，设置先手玩家费用=1
                uc.FullPower = 1;
                uc.Power = 1;
            }
            #endregion

            #region 调整游戏环境对象
            GameContext.CurrentTurnRemainingSecond = 60;
            GameContext.CurrentTurnCode = GameContext.NextTurnCode;
            GameContext.NextTurnCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameTurnCode);
            
            
            #endregion
        }

        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        public void TurnStart()
        {
            CardAbilityParameter cap = new CardAbilityParameter()
            {
                GameContext = GameContext
            };
            GameContext.EventQueue.AddLast(new MyTurnStartEvent() { Parameter = cap });

            var uc = GameContext.GetActivationUserContext();
            if (uc.FullPower < 10)
            {
                uc.FullPower += 1;
            }
            uc.Power = uc.FullPower;
            uc.ComboSwitch = false;

            //抽牌
            DrawCardActionParameter para = new DrawCardActionParameter()
            {
                DrawCount = 1,
                GameContext = GameContext,
                UserContext = uc
            };
            new DrawCardAction().Action(para);

            //GameContext.DrawCard();

            //将英雄技能可用次数重置为1次
            uc.RemainingHeroPowerCastCount = 1;

            var activationDeskCards = GameContext.DeskCards.GetDeskCardsByIsFirst(uc.IsFirst);
            //让场上的随从或英雄获取攻击次数
            foreach (var card in activationDeskCards.Where(c => c != null))
            {
                card.CanAttack = true;
                BaseActionParameter resetPara = CardActionFactory.CreateParameter(card, GameContext);
                CardActionFactory.CreateAction(card, ActionType.重置攻击次数).Action(resetPara);
            }
        }
    }
}
