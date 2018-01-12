using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    public static class BaseHeroAction
    {
        /// <summary>
        /// 英雄受到伤害时，扣除它的生命值，然后触发随从或英雄受伤后的技能
        /// </summary>
        /// <param name="context"></param>
        /// <param name="triggerCard"></param>
        /// <param name="sourceCard"></param>
        /// <param name="damege"></param>
        public static void DeductionBiologyLife(this BaseHero sourceCard, GameContext context, Card triggerCard,
            int damege)
        {
            sourceCard.Life -= damege;
            context.TriggerCardAbility(context.DeskCards, SpellCardAbilityTime.英雄受伤, triggerCard, sourceCard.DeskIndex);
            //BiologyDead(sourceCard, triggerCard, context);
        }

        /// <summary>
        /// 英雄死亡检测
        /// </summary>
        /// <param name="sourceCard"></param>
        /// <param name="targetCard"></param>
        /// <param name="context"></param>
        public static void BiologyDead(this BaseHero sourceCard, Card targetCard, GameContext context)
        {
            //英雄死亡
            if (sourceCard.Life < 1)
            {
                
            }
        }

        /// <summary>
        /// 英雄受到伤害（被火球砸、火冲点）
        /// </summary>
        public static void BiologyByDamege(this BaseHero sourceCard, Card targetCard, GameContext context, int damege)
        {
            var trueDamege = damege;
            if (sourceCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄受到伤害前)))
            {
                context.TriggerCardAbility(new List<Card> {sourceCard}, SpellCardAbilityTime.己方英雄受到伤害前, targetCard,
                    sourceCard.DeskIndex);
            }
            else
            {
                if (trueDamege >= sourceCard.Ammo)
                {
                    trueDamege -= sourceCard.Ammo;
                    sourceCard.Ammo = 0;
                }
                else
                {
                    sourceCard.Ammo -= trueDamege;
                    trueDamege = 0;
                }                
                DeductionBiologyLife(sourceCard, context, targetCard, trueDamege);
            }

            context.TriggerCardAbility(new List<Card> {sourceCard}, SpellCardAbilityTime.己方英雄受到伤害后, targetCard,
                sourceCard.DeskIndex);
        }


        /// <summary>
        ///     被攻击
        /// </summary>
        public static void UnderAttack(this BaseHero baseHero, GameContext gameContext, BaseBiology attackCard)
        {
            if (attackCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄受到伤害后)))
            {
                var abiliti = attackCard.Abilities.First(c =>
                    c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄受到伤害后));
                abiliti.CastAbility(gameContext, attackCard, baseHero, 0, baseHero.DeskIndex);
            }
            else
            {
                int trueDamege = attackCard.Damage;
                if (attackCard.CardType == CardType.英雄)
                {                    
                    BaseHero attackHero = attackCard as BaseHero;
                    if (attackHero.Equip != null)
                    {
                        trueDamege += attackHero.Equip.Damege;
                    }
                    
                }
                BiologyByDamege(baseHero, attackCard, gameContext, trueDamege);
            }
        }

        /// <summary>
        /// 攻击一个随从或英雄
        /// </summary>
        /// <param name="baseHero"></param>
        /// <param name="gameContext"></param>
        /// <param name="targetCard"></param>
        public static void Attack(this BaseHero baseHero, GameContext gameContext, BaseBiology targetCard)
        {
            if (baseHero.Equip != null)
            {
                if (baseHero.Equip.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄攻击前)))
                {
                    gameContext.TriggerCardAbility(new List<Card> { baseHero.Equip }, SpellCardAbilityTime.对方英雄攻击前, targetCard);
                }
                else
                {
                    targetCard.UnderAttack(gameContext, baseHero);
                }
                
                baseHero.Equip.Unload(gameContext);
            }
            else
            {
                targetCard.UnderAttack(gameContext, baseHero);
            }

            baseHero.RemainAttackTimes -= 1;
        }

        public static void Equip(this BaseHero baseHero, GameContext gameContext, BaseEquip equip)
        {
            if (baseHero.Equip != null)
            {
                var oldEquip = baseHero.Equip;
                oldEquip.CardLocation = CardLocation.坟场;
                if (oldEquip.Abilities.Any(c => c.AbilityType == AbilityType.亡语))
                    gameContext.TriggerCardAbility(new List<Card> {equip}, SpellCardAbilityTime.无, equip);                
            }
            baseHero.Equip = equip;
            baseHero.ResetRemainAttackTimes(gameContext);
        }

        /// <summary>
        /// 英雄进场（不触发技能，比如召唤出来的随从）
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="gameContext"></param>
        /// <param name="location"></param>
        /// <param name="target"></param>
        public static void Cast(this BaseHero hero, GameContext gameContext, int location, int target)
        {
            var user = gameContext.GetUserContextByMyCard(hero);
            gameContext.CastCardCount++;
            hero.CastIndex = gameContext.CastCardCount;
            hero.CardLocation = CardLocation.场上;
            hero.DeskIndex = location;
            BaseHero currentHero = gameContext.GetHeroByActivation(user.IsActivation);
            gameContext.DeskCards[user.IsFirst ? 0 : 8] = null;

            currentHero.CardLocation = CardLocation.坟场;
            currentHero = hero;

            
            
            if (user.HandCards.Any(c => c == hero))
            {
                user.HandCards.Remove(hero);
            }
            else if (user.StockCards.Any(c => c == hero))
            {
                user.StockCards.Remove(hero);
            }
            gameContext.DeskCards[user.IsActivation ? 0 : 8] = hero;
        }

        /// <summary>
        /// 重置英雄攻击次数
        /// </summary>
        /// <param name="biology"></param>
        /// <param name="gameContext"></param>
        public static void ResetRemainAttackTimes(this BaseHero hero, GameContext gameContext)
        {
            if (((hero.Equip != null && hero.Equip.Damege > 0) || hero.Damage > 0) && 
                hero.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.重置攻击次数)) == false)
            {
                hero.RemainAttackTimes += 1;
            }
            else
            {
                gameContext.TriggerCardAbility(new List<Card>() { hero }, SpellCardAbilityTime.重置攻击次数);
            }
        }
    }
}