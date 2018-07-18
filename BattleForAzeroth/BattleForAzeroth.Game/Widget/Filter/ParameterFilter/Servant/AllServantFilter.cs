using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant
{
    public class AllServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从);
        }
    }
}
