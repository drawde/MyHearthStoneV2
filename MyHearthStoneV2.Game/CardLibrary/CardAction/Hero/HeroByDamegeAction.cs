using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Hero;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到伤害（被火球砸、火冲点）
    /// </summary>
    internal class HeroByDamegeAction : IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            int damege = para.Damage;
            Card targetCard = para.SecondaryCard;

            var trueDamege = damege;
            if (baseHero.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄受到伤害前)))
            {
                gameContext.TriggerCardAbility(new List<Card> { baseHero }, SpellCardAbilityTime.己方英雄受到伤害前, targetCard,
                    baseHero.DeskIndex);
            }
            else
            {
                if (trueDamege >= baseHero.Ammo)
                {
                    trueDamege -= baseHero.Ammo;
                    baseHero.Ammo = 0;
                }
                else
                {
                    baseHero.Ammo -= trueDamege;
                    trueDamege = 0;
                }
                DeductionHeroLifeAction deductionAct = new DeductionHeroLifeAction();
                HeroActionParameter deductionPara = new HeroActionParameter()
                {
                    Biology = baseHero,
                    GameContext = gameContext,
                    SecondaryCard = targetCard,
                    Damage = trueDamege,
                };
                deductionAct.Action(deductionPara);
                //DeductionBiologyLife(baseHero, context, targetCard, trueDamege);
            }

            gameContext.TriggerCardAbility(new List<Card> { baseHero }, SpellCardAbilityTime.己方英雄受到伤害后, targetCard,
                baseHero.DeskIndex);
            return null;
        }
    }
}
