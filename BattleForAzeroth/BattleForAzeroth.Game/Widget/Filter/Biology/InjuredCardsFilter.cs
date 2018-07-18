using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System;

namespace BattleForAzeroth.Game.Widget.Filter.Biology
{
    public class InjuredCardsFilter<F> : ICardFilter where F : IParameterFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            F filter = Activator.CreateInstance<F>();
            return new Func<Card, bool>(c => (c.CardType == CardType.随从 || c.CardType == CardType.英雄) && (c as BaseBiology).Life < (c as BaseBiology).BuffLife);
        }
    }
}
