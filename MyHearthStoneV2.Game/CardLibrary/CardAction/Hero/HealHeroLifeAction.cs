using System;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Hero;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到治疗时，恢复它的生命值，然后触发随从或英雄受到治疗后的技能
    /// </summary>
    public class HealHeroLifeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            int heal = para.DamageOrHeal;
            baseHero.Life += heal;
            if (baseHero.Life > baseHero.BuffLife)
            {
                baseHero.Life = baseHero.BuffLife;
            }
            gameContext.TriggerCardAbility(baseHero, SpellCardAbilityTime.治疗);
            gameContext.TriggerCardAbility(baseHero, SpellCardAbilityTime.治疗英雄, AbilityType.无, para.SecondaryCard, baseHero.DeskIndex);
            return null;
        }
    }
}
