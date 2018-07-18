using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;

using System.Collections.Generic;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到治疗
    /// </summary>
    public class HeroByHealAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
            GameContext gameContext = para.GameContext;
            int heal = para.DamageOrHeal;
            Card targetCard = para.SecondaryCard;

            HealHeroLifeAction deductionAct = new HealHeroLifeAction();
            ActionParameter deductionPara = new ActionParameter()
            {
                PrimaryCard = baseHero,
                GameContext = gameContext,
                SecondaryCard = targetCard,
                DamageOrHeal = heal,
            };
            deductionAct.Action(deductionPara);
            return null;
        }
    }
}
