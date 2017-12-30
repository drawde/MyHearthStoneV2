
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Monitor;
using MyHearthStoneV2.CardLibrary.Servant;
using System.Linq;
using System.Collections.Generic;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Hero;

namespace MyHearthStoneV2.CardLibrary.Controler
{
    internal partial class Controler_Base
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        [ControlerMonitor, PlayerActionMonitor]
        internal void CastServant(BaseServant triggerCard, int location, int target)
        {
            #region 首先触发打出的这张牌的战吼技能
            if (triggerCard.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.战吼)))
            {
                foreach (var buff in triggerCard.Abilities.Where(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.战吼)))
                {
                    buff.CastAbility(gameContext, triggerCard, triggerCard, target, location);
                }
            }
            #endregion
            var user = gameContext.GetActivationUserContext();
            user.Power -= triggerCard.Cost;
            triggerCard.CardLocation = CardLocation.场上;
            triggerCard.DeskIndex = location;
            user.DeskCards[location < 8? location: location - 8] = triggerCard;
            user.HandCards.Remove(triggerCard);
            #region 然后触发场内牌的技能
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从入场, triggerCard, target);
            #endregion

            #region 最后触发手牌的技能
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.手牌, SpellCardAbilityTime.己方随从入场, triggerCard, target);
            #endregion
        }

        /// <summary>
        /// 随从攻击准备阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor, PlayerActionMonitor]
        internal void ServantReadyAttack(BaseServant servant, int target)
        {
        }

        /// <summary>
        /// 随从攻击进行阶段
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="target"></param>
        [ControlerMonitor, PlayerActionMonitor]
        internal void ServantAttack(BaseServant servant, int target)
        {
            gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从攻击, servant, target);
            gameContext.TriggerCardAbility(gameContext.GetNotActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方随从攻击, servant, target);
            BaseBiology targetBiology = gameContext.GetCardByLocation(target) as BaseBiology;
            if (targetBiology != null)
            {
                int trueDamege = servant.Damage;
                if (targetBiology is BaseHero)
                {
                    BaseHero hero = gameContext.GetCardByLocation(target) as BaseHero;
                    if (hero.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方英雄受到攻击)))
                    {
                        gameContext.TriggerCardAbility(new List<Card>() { hero }, CardLocation.场上, SpellCardAbilityTime.己方英雄受到攻击, servant, target);
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
                        gameContext.TriggerCardAbility(new List<Card>() { targetBiology }, CardLocation.场上, SpellCardAbilityTime.己方随从受到攻击, servant, target);
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
                        UserContext enemy = gameContext.GetNotActivationUserContext();
                        enemy.GraveyardCards.Add(targetBiology);

                        gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从入坟场, servant, target);
                        gameContext.TriggerCardAbility(gameContext.GetNotActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方随从入坟场, servant, target);
                    }

                    //攻击者也要受到被攻击者的伤害
                    if (servant.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.己方随从受到攻击)))
                    {
                        gameContext.TriggerCardAbility(new List<Card>() { servant }, CardLocation.场上, SpellCardAbilityTime.己方随从受到攻击, targetBiology, target);
                    }
                    else
                    {
                        servant.Life -= targetBiology.Damage;
                    }

                    //随从死亡
                    if (servant.Life < 1)
                    {
                        //随从进坟场
                        servant.CardLocation = CardLocation.坟场;
                        UserContext currentUser = gameContext.GetActivationUserContext();
                        currentUser.GraveyardCards.Add(servant);

                        gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从入坟场, targetBiology, target);
                        gameContext.TriggerCardAbility(gameContext.GetNotActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方随从入坟场, targetBiology, target);
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
        [ControlerMonitor, PlayerActionMonitor]
        internal void BiologyByDamege(Card sourceCard, int damege, int target)
        {
            BaseBiology targetBiology = gameContext.GetCardByLocation(target) as BaseBiology;
            if (targetBiology != null)
            {
                int trueDamege = damege;
                if (targetBiology is BaseHero)
                {
                    BaseHero hero = gameContext.GetCardByLocation(target) as BaseHero;
                    if (hero.Abilities.Any(c => c.LstSpellCardAbilityTime.Any(x => x == SpellCardAbilityTime.对方英雄受到伤害)))
                    {
                        gameContext.TriggerCardAbility(new List<Card>() { hero }, CardLocation.场上, SpellCardAbilityTime.对方英雄受到伤害, sourceCard, target);
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
                        gameContext.TriggerCardAbility(new List<Card>() { targetBiology }, CardLocation.场上, SpellCardAbilityTime.己方随从受到伤害, sourceCard, target);
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
                        UserContext enemy = gameContext.GetNotActivationUserContext();
                        enemy.GraveyardCards.Add(targetBiology);

                        gameContext.TriggerCardAbility(gameContext.GetActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.己方随从入坟场, sourceCard, target);
                        gameContext.TriggerCardAbility(gameContext.GetNotActivationUserContext().DeskCards, CardLocation.场上, SpellCardAbilityTime.对方随从入坟场, sourceCard, target);
                    }                                        
                }
            }
        }
    }
}
