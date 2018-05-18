using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.AbilityAttribute;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AddAmmo<UC, Q> : DefaultAttribute, ICardAbility where Q : INumber where UC : IUserContextFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
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
