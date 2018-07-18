using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter
{
    public class AllBiologyFilter : IParameterFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && (c.CardType == CardType.英雄 || c.CardType == CardType.随从));
        }
    }
}
