using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Widget;
using System;

namespace BattleForAzeroth.Game.Widget.Filter
{
    public interface ICardCondition
    {
        Func<Card, bool> Filter();
    }
}
