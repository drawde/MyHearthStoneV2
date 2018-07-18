using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter
{
    public class NoneFilter : IParameterFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null);
        }
    }
}
