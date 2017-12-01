using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.ShortCodeBll;
using System.Collections.Generic;
using System.Linq;
namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 回合结束
        /// </summary>        
        [ControlerMonitor, PlayerActionMonitor]
        public void TurnEnd()
        {
            TriggerCardAbility(GetCurrentTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方回合结束);
            TriggerCardAbility(GetNextTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方回合结束);

            //获取是自己的牌的技能所影响的牌
            var myBuffCards = gameContext.AllCard.Where(c => IsThisActivationUserCard(c.Buffs.Keys.ToList()));
            DisableCardAbility(myBuffCards, CardLocation.场上, BuffTimeLimit.己方回合结束);

            #region 调整玩家对象
            UserContext uc = null, next_uc = null;
            if (TurnIndex > 0)
            {
                uc = GetCurrentTurnUserCards();
                next_uc = GetNextTurnUserCards();
                uc.IsActivation = false;
                next_uc.IsActivation = true;
                //if (next_uc.Power < 11)
                //{
                //    next_uc.Power++;
                //}
            }
            //else
            //{
            //    uc = gameContext.Players.First(c => c.IsFirst);
            //    next_uc = gameContext.Players.First(c => c.IsFirst == false);
            //    uc.IsActivation = true;
            //    next_uc.IsActivation = false;
            //}
            #endregion

            #region 调整游戏环境对象
            currentTurnRemainingSecond = 60;
            currentTurnCode = nextTurnCode;
            nextTurnCode = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.GameTurnCode);
            TurnIndex++;
            
            #endregion
        }

        [ControlerMonitor, PlayerActionMonitor]
        public void TurnStart()
        {
            TriggerCardAbility(GetCurrentTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方回合开始);
            TriggerCardAbility(GetNextTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方回合开始);

            //获取是自己的牌的技能所影响的牌
            var myBuffCards = gameContext.AllCard.Where(c => IsThisActivationUserCard(c.Buffs.Keys.ToList()));
            DisableCardAbility(myBuffCards, CardLocation.场上, BuffTimeLimit.己方回合开始);

            var uc = GetCurrentTurnUserCards();
            if (uc.FullPower < 10)
            {
                uc.FullPower += 1;
            }
            uc.Power = uc.FullPower;

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
                    TriggerCardAbility(uc.DeskCards, CardLocation.场上, SpellCardAbilityTime.己方英雄受到伤害);
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
}
