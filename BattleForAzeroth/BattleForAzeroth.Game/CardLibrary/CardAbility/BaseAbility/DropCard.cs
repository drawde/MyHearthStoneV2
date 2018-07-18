using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.CardAction.Player;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Widget.Condition.Pick;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class DropCard<UC, Q, P> : ICardAbility where UC : IUserContextFilter where Q : INumber where P : IPickType
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            Q dropCount = GameActivator<Q>.CreateInstance();
            P pickType = GameActivator<P>.CreateInstance();
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                var para = new ActionParameter()
                {
                    PrimaryCard = actionParameter.PrimaryCard,
                    DropCount = dropCount.GetNumber(actionParameter),
                    GameContext = actionParameter.GameContext,
                    UserContext = user,
                    DropCardType = pickType.PickType
                };
                new DropCardAction().Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
