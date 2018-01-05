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
    }
}
