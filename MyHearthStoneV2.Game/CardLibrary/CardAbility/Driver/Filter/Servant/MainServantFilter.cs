using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant
{
    public class MainServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && c.CardInGameCode == actionParameter.MainCard.CardInGameCode);
        }
    }
}
