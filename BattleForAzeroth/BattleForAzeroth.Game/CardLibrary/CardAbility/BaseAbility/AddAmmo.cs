using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.CardLibrary.CardAbility.AbilityAttribute;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AddAmmo<UC, Q> : DefaultAttribute, ICardAbility where Q : INumber where UC : IUserContextFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                BaseHero hero = actionParameter.GameContext.DeskCards.GetHeroByIsFirst(user.IsFirst);
                hero.Ammo += GameActivator<Q>.CreateInstance().GetNumber(actionParameter);
            }            
            return null;
        }

        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
