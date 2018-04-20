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
    /// 英雄受到治疗
    /// </summary>
    public class HeroByHealAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            int heal = para.DamageOrHeal;
            Card targetCard = para.SecondaryCard;
            
            if (baseHero.Abilities.Any(c => c.SpellCardAbilityTimes.Any(x => x == SpellCardAbilityTime.己方英雄受到治疗前)))
            {
                gameContext.TriggerCardAbility(new List<Card> { baseHero }, SpellCardAbilityTime.己方英雄受到治疗前, targetCard,
                    baseHero.DeskIndex);
            }
            else
            {
                HealHeroLifeAction deductionAct = new HealHeroLifeAction();
                HeroActionParameter deductionPara = new HeroActionParameter()
                {
                    Biology = baseHero,
                    GameContext = gameContext,
                    SecondaryCard = targetCard,
                    DamageOrHeal = heal,
                };
                deductionAct.Action(deductionPara);
                //DeductionBiologyLife(baseHero, context, targetCard, trueDamege);
            }

            gameContext.TriggerCardAbility(new List<Card> { baseHero }, SpellCardAbilityTime.己方英雄受到治疗后, targetCard,
                baseHero.DeskIndex);
            return null;
        }
    }
}
