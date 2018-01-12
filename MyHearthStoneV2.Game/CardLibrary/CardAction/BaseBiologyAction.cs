using MyHearthStoneV2.Game.Context;
using System.Linq;
using MyHearthStoneV2.Game.Controler;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Equip;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Servant;
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction
{
    public static class BaseBiologyAction
    {
        /// <summary>
        /// 随从或英雄受到伤害时，扣除它的生命值，然后触发随从或英雄受伤后的技能
        /// </summary>
        /// <param name="context"></param>
        /// <param name="triggerCard"></param>
        /// <param name="sourceCard"></param>
        /// <param name="damege"></param>
        public static void DeductionBiologyLife(this BaseBiology sourceCard, GameContext context, Card triggerCard, int damege)
        {
            if (sourceCard.CardType == CardType.英雄)
            {
                BaseHeroAction.DeductionBiologyLife(sourceCard as BaseHero, context, triggerCard, damege);
            }
            else
            {
                BaseServantAction.DeductionBiologyLife(sourceCard as BaseServant, context, triggerCard, damege);
            }
        }

        /// <summary>
        /// 生物死亡检测
        /// </summary>
        /// <param name="sourceCard"></param>
        /// <param name="context"></param>
        /// <param name="triggerCard"></param>
        public static void BiologyDead(this BaseBiology sourceCard, GameContext context, Card triggerCard)
        {
            if (sourceCard.CardType == CardType.英雄)
            {
                BaseHeroAction.BiologyDead(sourceCard as BaseHero, triggerCard, context);
            }
            else
            {
                BaseServantAction.BiologyDead(sourceCard as BaseServant, triggerCard, context);
            }
        }

        /// <summary>
        /// 随从、英雄受到伤害（被火球砸、火冲点）
        /// </summary>
        public static void BiologyByDamege(this BaseBiology sourceCard, Card targetCard, GameContext context, int damege)
        {
            if (sourceCard.CardType == CardType.英雄)
            {
                BaseHeroAction.BiologyByDamege(sourceCard as BaseHero, targetCard, context, damege);
            }
            else
            {
                BaseServantAction.BiologyByDamege(sourceCard as BaseServant, targetCard, context, damege);
            }
        }




        /// <summary>
        /// 被攻击
        /// </summary>
        public static void UnderAttack(this BaseBiology sourceCard, GameContext gameContext, BaseBiology attackCard)
        {
            if (sourceCard.CardType == CardType.英雄)
            {
                BaseHeroAction.UnderAttack(sourceCard as BaseHero, gameContext, attackCard);
            }
            else
            {
                BaseServantAction.UnderAttack(sourceCard as BaseServant, gameContext, attackCard);
            }
        }

        /// <summary>
        /// 攻击一个随从或英雄
        /// </summary>
        /// <param name="biology"></param>
        /// <param name="gameContext"></param>
        /// <param name="targetCard"></param>
        public static void Attack(this BaseBiology sourceCard, GameContext gameContext, BaseBiology targetCard)
        {
            if (sourceCard.CardType == CardType.英雄)
            {
                BaseHeroAction.Attack(sourceCard as BaseHero, gameContext, targetCard);
            }
            else
            {
                BaseServantAction.Attack(sourceCard as BaseServant, gameContext, targetCard);
            }
        }

        /// <summary>
        /// 随从或英雄进场（不触发技能，比如召唤出来的随从）
        /// </summary>
        /// <param name="biology"></param>
        /// <param name="gameContext"></param>
        /// <param name="location"></param>
        /// <param name="target"></param>
        public static void Cast(this BaseBiology biology, GameContext gameContext, int location, int target)
        {
            if (biology.CardType == CardType.英雄)
            {
                BaseHeroAction.Cast(biology as BaseHero, gameContext, location, target);
            }
            else
            {
                BaseServantAction.Cast(biology as BaseServant, gameContext, location, target);
            }
        }

        /// <summary>
        /// 重置随从或英雄攻击次数
        /// </summary>
        /// <param name="biology"></param>
        /// <param name="gameContext"></param>
        public static void ResetRemainAttackTimes(this BaseBiology biology, GameContext gameContext)
        {
            if (biology.CardType == CardType.英雄)
            {
                BaseHeroAction.ResetRemainAttackTimes(biology as BaseHero, gameContext);
            }
            else
            {
                BaseServantAction.ResetRemainAttackTimes(biology as BaseServant, gameContext);
            }
        }
    }
}
