using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.Widget.Filter
{
    public interface ICardFilter//<C> where C: ICardCondition
    {
        Func<Card, bool> Filter(ActionParameter actionParameter);
    }
}
