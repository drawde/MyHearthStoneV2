using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AddPower<UC, Q> : ICardAbility where UC : IUserContextFilter where Q : INumber
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                user.Power += GameActivator<Q>.CreateInstance().GetNumber(actionParameter);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
