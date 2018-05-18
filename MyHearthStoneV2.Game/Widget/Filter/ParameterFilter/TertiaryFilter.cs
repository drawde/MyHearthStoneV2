using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter
{
    public class TertiaryFilter : IParameterFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardInGameCode == actionParameter.TertiaryCard.CardInGameCode);
        }
    }
}
