using MyHearthStoneV2.Game.Context;
using System.Linq;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Servant
{
    public static class BaseServantAction
    {
        

        /// <summary>
        /// 随从受到伤害时，扣除它的生命值，然后触发随从或英雄受伤后的技能
        /// </summary>
        /// <param name="context"></param>
        /// <param name="triggerCard"></param>
        /// <param name="sourceCard"></param>
        /// <param name="damege"></param>
        public static void DeductionBiologyLife(this BaseServant sourceCard, GameContext context, Card triggerCard, int damege)
        {
            sourceCard.Life -= damege;
            if (sourceCard.CardType == CardType.英雄)
            {
                context.TriggerCardAbility(context.DeskCards, SpellCardAbilityTime.英雄受伤, triggerCard, sourceCard.DeskIndex);
            }
            else
            {
                context.TriggerCardAbility(context.DeskCards, SpellCardAbilityTime.随从受伤, triggerCard, sourceCard.DeskIndex);
            }
        }
        /// <summary>
        /// 随从受到伤害（被火球砸、火冲点）
        /// </summary>
        public static void BiologyByDamege(this BaseServant sourceCard, Card targetCard, GameContext context, int damege)
        {
            int trueDamege = damege;
            if (sourceCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方随从受到伤害前)))
            {
                context.TriggerCardAbility(new List<Card>() { sourceCard }, SpellCardAbilityTime.己方随从受到伤害前, targetCard, sourceCard.DeskIndex);
            }
            else
            {
                DeductionBiologyLife(sourceCard, context, targetCard, trueDamege);
            }
            context.TriggerCardAbility(new List<Card>() { sourceCard }, SpellCardAbilityTime.己方随从受到伤害后, targetCard, sourceCard.DeskIndex);
            //随从死亡
            if (sourceCard.Life < 1)
            {
                //随从进坟场
                sourceCard.CardLocation = CardLocation.坟场;
                UserContext enemy = context.GetNotActivationUserContext();
                enemy.GraveyardCards.Add(sourceCard);

                context.TriggerCardAbility(context.GetActivationUserContext().DeskCards, SpellCardAbilityTime.己方随从入坟场, targetCard, sourceCard.DeskIndex);
                context.TriggerCardAbility(context.GetNotActivationUserContext().DeskCards, SpellCardAbilityTime.对方随从入坟场, targetCard, sourceCard.DeskIndex);
            }
        }


        

        /// <summary>
        /// 被攻击
        /// </summary>
        public static void UnderAttack(this BaseServant servant, GameContext gameContext, BaseBiology attackCard)
        {
            if (attackCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方随从受到伤害后)))
            {
                var abiliti = attackCard.Abilities.First(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方随从受到伤害后));
                abiliti.CastAbility(gameContext, attackCard, servant, 0, servant.DeskIndex);
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
                BiologyByDamege(servant, attackCard, gameContext, trueDamege);
            }
        }

        /// <summary>
        /// 攻击一个随从
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="gameContext"></param>
        /// <param name="targetCard"></param>
        public static void Attack(this BaseServant servant, GameContext gameContext, BaseBiology targetCard)
        {
            //攻击对方
            targetCard.UnderAttack(gameContext, servant);

            //自己挨打
            UnderAttack(servant, gameContext, targetCard);            
            servant.RemainAttackTimes -= 1;
        }
    }
}