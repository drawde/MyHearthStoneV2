using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.CardLibrary.CardAction.Player;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.GameProcess;

using BattleForAzeroth.Game.Parameter;
using System.Collections.Generic;
using System.Linq;
using BattleForAzeroth.Game.Util;

namespace BattleForAzeroth.Game.Controler
{
    public partial class Controler_Base
    {        
        /// <summary>
        /// 回合结束
        /// </summary>                
        public void TurnEnd(IShortCodeService shortCodeService)
        {
            UserContext uc = GameContext.GetActivationUserContext(), next_uc = null;

            List<Card> buffCards = new List<Card>();
            buffCards.AddRange(GameContext.DeskCards.GetDeskCardsByIsFirst(uc.IsFirst));
            buffCards.AddRange(uc.HandCards);
            buffCards = buffCards.Where(c => c != null && c.Buffs.Count > 0).ToList();
            foreach (Card card in buffCards)
            {
                LinkedListNode<IBuffRestore<ICardLocationFilter, IEvent>> buff = card.Buffs.First;
                while (buff != null)
                {
                    buff.Value.Action(new ActionParameter()
                    {
                        GameContext = GameContext,
                        PrimaryCard = card
                    });
                }
            }

            
            #region 调整玩家对象
            if (GameContext.TurnIndex > 0)
            {                
                next_uc = GameContext.GetNotActivationUserContext();

                var para = new ActionParameter()
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
                _gameCache.SetContext(GameContext);
                //DataExchangeBll.Instance.AsyncInsert("TurnEnd", "Controler_Base", "", JsonConvert.SerializeObject(GameContext), DataSourceEnum.GameControler);
                
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
            GameContext.NextTurnCode = shortCodeService.CreateCode(3);            
            GameContext.TurnIndex++;

            #endregion
            Settlement();
        }

        public void TurnStart()
        {
            var cap = new ActionParameter()
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
            var para = new ActionParameter()
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
                ActionParameter resetPara = new ActionParameter()
                {
                    PrimaryCard = card,
                    GameContext = GameContext
                };
                CardActionFactory.CreateAction(card, ActionType.重置攻击次数).Action(resetPara);
            }
            Settlement();
        }
    }
}
