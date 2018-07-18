using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter
{
    public class TertiaryFilter : IParameterFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardInGameCode == actionParameter.TertiaryCard.CardInGameCode);
        }
    }
}
