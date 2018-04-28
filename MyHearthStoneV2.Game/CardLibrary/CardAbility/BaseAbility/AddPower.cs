using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AddPower<UC, Q> : ICardAbility where UC : IUserContextFilter where Q : INumber
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
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
