
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.Servant;
using System.Linq;
using System.Collections.Generic;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Hero;

namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        [ControlerMonitor, PlayerActionMonitor]
        public void CastServant(BaseServant triggerCard, int location, List<int> target)
        {
            #region 首先触发打出的这张牌的技能
            if (triggerCard.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方随从入场)))
            {
                foreach (var buff in triggerCard.Abilities.Where(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方随从入场)))
                {
                    buff.CastAbility(gameContext, triggerCard, triggerCard, target, location);
                }
            }
            #endregion
            var user = GetCurrentTurnUserCards();
            user.Power -= triggerCard.Cost;
            triggerCard.CardLocation = CardLocation.场上;
            user.DeskCards[location] = triggerCard;

            #region 然后触发场内牌的技能
            TriggerCardAbility(GetCurrentTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从入场, triggerCard, target);
            #endregion

            #region 最后触发手牌的技能
            TriggerCardAbility(GetCurrentTurnUserCards().DeskCards, CardLocation.手牌, SpellCardAbilityTime.己方随从入场, triggerCard, target);
            #endregion
        }

        /// <summary>
        /// 随从攻击
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor, PlayerActionMonitor]
        public void ServantAttack(BaseServant servant, int target)
        {
            TriggerCardAbility(GetCurrentTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从攻击, servant, new List<int>() { target });
            TriggerCardAbility(GetNextTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方随从攻击, servant, new List<int>() { target });
            BaseBiology targetBiology = GetCardByLocation(target) as BaseBiology;
            if (targetBiology != null)
            {
                int trueDamege = servant.Damage;
                if (targetBiology is BaseHero)
                {
                    BaseHero hero = GetCardByLocation(target) as BaseHero;
                    if (hero.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方英雄受到攻击)))
                    {
                        TriggerCardAbility(new List<Card>() { hero }, CardLocation.场上, SpellCardAbilityTime.己方英雄受到攻击, servant, new List<int>() { target });
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
                    if (targetBiology.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方随从受到攻击)))
                    {
                        TriggerCardAbility(new List<Card>() { targetBiology }, CardLocation.场上, SpellCardAbilityTime.己方随从受到攻击, servant, new List<int>() { target });
                    }
                    else
                    {
                        targetBiology.Life -= trueDamege;
                    }
                    //随从死亡
                    if (targetBiology.Life < 1)
                    {
                        targetBiology.CardLocation = CardLocation.坟场;
                        TriggerCardAbility(GetCurrentTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从入坟场, servant, new List<int>() { target });
                        TriggerCardAbility(GetNextTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方随从入坟场, servant, new List<int>() { target });
                    }

                    //攻击者也要受到被攻击者的伤害
                    if (servant.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方随从受到攻击)))
                    {
                        TriggerCardAbility(new List<Card>() { servant }, CardLocation.场上, SpellCardAbilityTime.己方随从受到攻击, targetBiology, new List<int>() { target });
                    }
                    else
                    {
                        servant.Life -= targetBiology.Damage;
                    }

                    //随从死亡
                    if (servant.Life < 1)
                    {
                        servant.CardLocation = CardLocation.坟场;
                        TriggerCardAbility(GetCurrentTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从入坟场, targetBiology, new List<int>() { target });
                        TriggerCardAbility(GetNextTurnUserCards().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方随从入坟场, targetBiology, new List<int>() { target });
                    }
                }
            }
        }
    }
}
