using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.CardAction;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Monitor;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.ShortCodeBll;
using System.Linq;
namespace MyHearthStoneV2.Game.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 回合结束
        /// </summary>                
        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void TurnEnd()
        {
            UserContext uc = null, next_uc = null;
            
            #region 调整玩家对象
            
            if (GameContext.TurnIndex > 0)
            {
                uc = GameContext.GetActivationUserContext();
                next_uc = GameContext.GetNotActivationUserContext();

                GameContext.TriggerCardAbility(GameContext.DeskCards.GetDeskCardsByIsFirst(uc.IsFirst), SpellCardAbilityTime.己方回合结束);
                GameContext.TriggerCardAbility(GameContext.DeskCards.GetDeskCardsByIsFirst(next_uc.IsFirst), SpellCardAbilityTime.对方回合结束);

                uc.IsActivation = false;
                next_uc.IsActivation = true;
                if (GameContext.DeskCards.Any(c => c != null))
                {
                    foreach (var bio in GameContext.DeskCards.Where(c => c != null))
                    {
                        BaseBiology biology = bio as BaseBiology;
                        biology.RemainAttackTimes = 0;
                    }
                }
                //if (next_uc.Power < 11)
                //{
                //    next_uc.Power++;
                //}
            }
            else
            {
                //开局换完牌后，设置先手玩家费用=1
                uc = GameContext.GetActivationUserContext();
                uc.FullPower = 1;
                uc.Power = 1;
            }
            #endregion

            #region 调整游戏环境对象
            GameContext.CurrentTurnRemainingSecond = 60;
            GameContext.CurrentTurnCode = GameContext.NextTurnCode;
            GameContext.NextTurnCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameTurnCode);
            GameContext.TurnIndex++;
            
            #endregion
        }

        [ControlerMonitor(AttributePriority = 99), PlayerActionMonitor(AttributePriority = 98), UserActionMonitor(AttributePriority = 1)]
        internal void TurnStart()
        {
            GameContext.TriggerCardAbility(GameContext.DeskCards.GetDeskCardsByIsFirst(), SpellCardAbilityTime.己方回合开始);
            GameContext.TriggerCardAbility(GameContext.DeskCards.GetDeskCardsByIsFirst(false), SpellCardAbilityTime.对方回合开始);

            //获取是自己的牌的技能所影响的牌
            //var myBuffCards = gameContext.AllCard.Where(c => gameContext.IsThisActivationUserCard(c.Buffs.Keys.ToList()));
            //gameContext.DisableCardAbility(myBuffCards, CardLocation.场上, BuffTimeLimit.己方回合开始);

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
            if (activationDeskCards.Any(c => c != null))
            {
                foreach (var card in activationDeskCards.Where(c => c != null))
                {
                    //if (card.CardType == CardType.随从 && card.Damage < 1)
                    //{
                    //    card.CanAttack = false;
                    //}
                    //else
                    //{
                    //    card.CanAttack = true;
                    //}
                    card.CanAttack = true;
                    BaseActionParameter resetPara = CardActionFactory.CreateParameter(card, GameContext);
                    CardActionFactory.CreateAction(card, ActionType.重置攻击次数).Action(resetPara);
                }
            }
        }
    }
}
