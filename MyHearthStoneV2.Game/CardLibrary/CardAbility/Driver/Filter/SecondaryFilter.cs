using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter
{
    public class SecondaryFilter: IFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardInGameCode == actionParameter.SecondaryCard.CardInGameCode);
        }
    }
}
