using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
using System;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class ArmorPenetration<Hero, Q> : ICardAbility where Hero : IHeroFilter where Q : INumber
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            Hero heroFilter = Activator.CreateInstance<Hero>();
            Q damege = GameActivator<Q>.CreateInstance();

            var heros = actionParameter.GameContext.DeskCards.Where(heroFilter.Filter(actionParameter));
            foreach (Card card in heros)
            {
                BaseHero hero = card as BaseHero;
                //将护甲削减为0
                int ammo = hero.Ammo;
                hero.Ammo = 0;
                ActionParameter para = new ActionParameter
                {
                    PrimaryCard = hero,
                    GameContext = actionParameter.GameContext,
                    DamageOrHeal = damege.GetNumber(actionParameter),
                    SecondaryCard = actionParameter.PrimaryCard
                };
                CardActionFactory.CreateAction(hero, ActionType.受到伤害).Action(para);                
                hero.Ammo = ammo;
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
