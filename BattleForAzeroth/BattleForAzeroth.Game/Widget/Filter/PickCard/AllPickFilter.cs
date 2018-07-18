using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Filter.PickCard
{
    public class AllPickFilter : ICardPickFilter
    {
        public IEnumerable<Card> Filter(IList<Card> cards, ActionParameter baseActionParameter)
        {
            return cards;
        }
    }
}
