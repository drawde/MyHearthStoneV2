using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.Widget.Filter.PickCard
{
    public interface ICardPickFilter
    {
        IEnumerable<Card> Filter(IList<Card> cards, ActionParameter baseActionParameter);
    }
}
