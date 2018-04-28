using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter
{
    public class TertiaryFilter : IFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardInGameCode == actionParameter.TertiaryCard.CardInGameCode);
        }
    }
}
