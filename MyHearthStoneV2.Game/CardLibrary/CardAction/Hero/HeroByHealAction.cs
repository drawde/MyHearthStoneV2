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

            HealHeroLifeAction deductionAct = new HealHeroLifeAction();
            HeroActionParameter deductionPara = new HeroActionParameter()
            {
                Biology = baseHero,
                GameContext = gameContext,
                SecondaryCard = targetCard,
                DamageOrHeal = heal,
            };
            deductionAct.Action(deductionPara);
            return null;
        }
    }
}
