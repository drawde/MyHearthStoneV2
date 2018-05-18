using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System;

namespace MyHearthStoneV2.Game.Widget.Filter.Biology
{
    public class InjuredCardsFilter<F> : ICardFilter where F : IParameterFilter
    {
        public Func<Card, bool> Filter()
        {
            F filter = Activator.CreateInstance<F>();
            return new Func<Card, bool>(c => (c.CardType == CardType.随从 || c.CardType == CardType.英雄) && (c as BaseBiology).Life < (c as BaseBiology).BuffLife);
        }
    }
}
