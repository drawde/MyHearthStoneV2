using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Context;
using System.Linq;

namespace MyHearthStoneV2.Game.Widget.Condition.Assert.ServantAssert
{
    public class PrimaryUserHasServant : IAssert
    {
        public bool True(BaseActionParameter actionParameter)
        {
            Card card = actionParameter.PrimaryCard;
            return actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(actionParameter.GameContext.GetUserContextByMyCard(card).IsFirst).Any(c => c != null);
        }
    }
}
