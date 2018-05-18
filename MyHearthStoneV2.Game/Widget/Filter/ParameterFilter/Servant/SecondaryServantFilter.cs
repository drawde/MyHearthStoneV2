using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant
{
    public class SecondaryServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && c.CardInGameCode == actionParameter.SecondaryCard.CardInGameCode);
        }
    }
}
