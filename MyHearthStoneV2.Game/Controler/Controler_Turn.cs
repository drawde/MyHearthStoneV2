using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.ShortCodeBll;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.CardLibrary.CardAbility;
namespace MyHearthStoneV2.CardLibrary.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 回合结束
        /// </summary>        
        [ControlerMonitor, PlayerActionMonitor]
        internal void TurnEnd()
        {
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方回合结束);
            gameContext.TriggerCardAbility(gameContext.GetNotActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方回合结束);

            //获取是自己的牌的技能所影响的牌
            //var myBuffCards = gameContext.AllCard.Where(c => gameContext.IsThisActivationUserCard(c.Buffs.Keys.ToList()));
            //gameContext.DisableCardAbility(myBuffCards, CardLocation.场上, BuffTimeLimit.己方回合结束);

            #region 调整玩家对象
            UserContext uc = null, next_uc = null;
            if (TurnIndex > 0)
            {
                uc = gameContext.GetActivationUserContext();
                next_uc = gameContext.GetNotActivationUserContext();
                uc.IsActivation = false;
                next_uc.IsActivation = true;
                if (uc.DeskCards.Any(c => c != null))
                {
                    foreach (var bio in uc.DeskCards.Where(c => c != null))
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
                uc = gameContext.GetActivationUserContext();
                uc.FullPower = 1;
                uc.Power = 1;
            }
            #endregion

            #region 调整游戏环境对象
            currentTurnRemainingSecond = 60;
            currentTurnCode = nextTurnCode;
            nextTurnCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameTurnCode);
            TurnIndex++;
            
            #endregion
        }

        [ControlerMonitor, PlayerActionMonitor]
        internal void TurnStart()
        {
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方回合开始);
            gameContext.TriggerCardAbility(gameContext.GetNotActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方回合开始);

            //获取是自己的牌的技能所影响的牌
            //var myBuffCards = gameContext.AllCard.Where(c => gameContext.IsThisActivationUserCard(c.Buffs.Keys.ToList()));
            //gameContext.DisableCardAbility(myBuffCards, CardLocation.场上, BuffTimeLimit.己方回合开始);

            var uc = gameContext.GetActivationUserContext();
            if (uc.FullPower < 10)
            {
                uc.FullPower += 1;
            }
            uc.Power = uc.FullPower;

            //抽牌
            gameContext.DrawCard();

            //将英雄技能可用次数重置为1次
            uc.RemainingHeroPowerCastCount = 1;

            //让场上的随从或英雄获取攻击次数
            if (uc.DeskCards.Any(c => c != null))
            {
                foreach (var card in uc.DeskCards.Where(c => c != null))
                {
                    var biology = card as BaseBiology;
                    if (biology.Damage > 0)
                    {
                        biology.RemainAttackTimes += 1;
                        if (biology.Abilities.Any(c => c is Windfury))
                        {
                            biology.RemainAttackTimes += 1;
                        }
                    }
                }
            }
        }
    }
}
