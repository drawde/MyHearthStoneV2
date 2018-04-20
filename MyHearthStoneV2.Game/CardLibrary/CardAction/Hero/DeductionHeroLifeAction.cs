using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Hero;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到伤害时，扣除它的生命值，然后触发随从或英雄受伤后的技能
    /// </summary>
    public class DeductionHeroLifeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            HeroActionParameter para = actionParameter as HeroActionParameter;
            BaseHero baseHero = para.Biology;
            GameContext gameContext = para.GameContext;
            int damage = para.DamageOrHeal;
            baseHero.Life -= damage;
            gameContext.TriggerCardAbility(baseHero, SpellCardAbilityTime.受伤);
            gameContext.TriggerCardAbility(baseHero, SpellCardAbilityTime.英雄受伤, AbilityType.无, para.SecondaryCard, baseHero.DeskIndex);
            return null;
        }
    }
}
