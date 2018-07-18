using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event.Trigger;
using BattleForAzeroth.Game.Parameter;


namespace BattleForAzeroth.Game.CardLibrary.CardAction.Hero
{
    /// <summary>
    /// 英雄受到伤害时，扣除它的生命值，然后触发随从或英雄受伤后的技能
    /// </summary>
    public class DeductionHeroLifeAction : Action.IGameAction
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            ActionParameter para = actionParameter as ActionParameter;
            BaseHero baseHero = para.PrimaryCard as BaseHero;
            GameContext gameContext = para.GameContext;
            int damage = para.DamageOrHeal;

            if (baseHero.HasHolyShield)
            {
                baseHero.HasHolyShield = false;
            }
            else
            {
                baseHero.Life -= damage;
            }

            gameContext.EventQueue.AddLast(new AnyHurtEvent() { EventCard = baseHero, Parameter = para });
            return null;
        }
    }
}
