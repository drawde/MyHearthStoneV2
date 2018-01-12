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

            //BiologyDead(sourceCard, targetCard, context);
        }

        /// <summary>
        /// 随从死亡检测
        /// </summary>
        /// <param name="sourceCard"></param>
        /// <param name="targetCard"></param>
        /// <param name="context"></param>
        public static void BiologyDead(this BaseServant sourceCard, Card targetCard, GameContext context)
        {
            //随从死亡
            if (sourceCard.Life < 1)
            {
                //随从进坟场
                sourceCard.CardLocation = CardLocation.坟场;
                UserContext uc = context.GetUserContextByMyCard(sourceCard);
                uc.GraveyardCards.Add(sourceCard);
                context.DeskCards[context.DeskCards.FindIndex(c => c != null && c.CardInGameCode == sourceCard.CardInGameCode)] = null;

                context.TriggerCardAbility(new List<Card>() { sourceCard }, SpellCardAbilityTime.随从死亡, targetCard, sourceCard.DeskIndex);
                context.TriggerCardAbility(context.DeskCards.GetDeskCardsByEnemyCard(sourceCard), SpellCardAbilityTime.对方随从入坟场, targetCard, sourceCard.DeskIndex);
            }
        }




        /// <summary>
        /// 被攻击
        /// </summary>
        public static void UnderAttack(this BaseServant servant, GameContext gameContext, BaseBiology attackCard)
        {
            if (attackCard.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.随从攻击)))
            {
                var abiliti = attackCard.Abilities.First(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.随从攻击));
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

        /// <summary>
        /// 随从进场（不触发技能，比如召唤出来的随从）
        /// </summary>
        /// <param name="servant"></param>
        /// <param name="gameContext"></param>
        /// <param name="location"></param>
        /// <param name="target"></param>
        public static void Cast(this BaseServant servant, GameContext gameContext, int location, int target)
        {
            var user = gameContext.GetUserContextByMyCard(servant);
            gameContext.CastCardCount++;
            servant.CastIndex = gameContext.CastCardCount;
            servant.CardLocation = CardLocation.场上;
            servant.DeskIndex = location;
            gameContext.DeskCards[location] = servant;
            user.HandCards.Remove(servant);
        }

        /// <summary>
        /// 重置随从攻击次数
        /// </summary>
        /// <param name="biology"></param>
        /// <param name="gameContext"></param>
        public static void ResetRemainAttackTimes(this BaseServant servant, GameContext gameContext)
        {
            if (servant.Damage > 0 && servant.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.重置攻击次数)) == false)
            {
                servant.RemainAttackTimes += 1;
            }
            else
            {
                gameContext.TriggerCardAbility(new List<Card>() { servant }, SpellCardAbilityTime.重置攻击次数);
            }
        }
    }
}