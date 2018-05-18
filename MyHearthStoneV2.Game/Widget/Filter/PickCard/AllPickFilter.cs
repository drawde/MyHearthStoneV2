using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Widget.Filter.PickCard
{
    public class AllPickFilter : ICardPickFilter
    {
        public IEnumerable<Card> Filter(IList<Card> cards, BaseActionParameter baseActionParameter)
        {
            return cards;
        }
    }
}
