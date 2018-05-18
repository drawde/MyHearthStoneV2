using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.Widget.Filter.PickCard
{
    public interface ICardPickFilter
    {
        IEnumerable<Card> Filter(IList<Card> cards, BaseActionParameter baseActionParameter);
    }
}
