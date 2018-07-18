using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.Widget.Filter.Servant
{
    public class NullServantFilter : IServantCardFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => true);
        }
    }
}
