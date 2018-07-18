using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Context;
using System.Linq;

namespace BattleForAzeroth.Game.Widget.Condition.Assert.ServantAssert
{
    public class PrimaryUserHasServant : IAssert
    {
        public bool True(ActionParameter actionParameter)
        {
            Card card = actionParameter.PrimaryCard;
            return actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(actionParameter.GameContext.GetUserContextByMyCard(card).IsFirst).Any(c => c != null);
        }
    }
}
