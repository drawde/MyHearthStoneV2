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
        }

        /// <summary>
        ///     随从、英雄受到伤害（被火球砸、火冲点）
        /// </summary>
        public static void BiologyByDamege(this BaseHero sourceCard, Card targetCard, GameContext context, int damege)
        {
            var trueDamege = damege;
            if (sourceCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.对方英雄受到伤害前)))
            {
                context.TriggerCardAbility(new List<Card> {sourceCard}, SpellCardAbilityTime.对方英雄受到伤害后, targetCard,
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

            context.TriggerCardAbility(new List<Card> {sourceCard}, SpellCardAbilityTime.对方英雄受到伤害后, targetCard,
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
                baseHero.Equip = equip;
            }
        }
    }
}