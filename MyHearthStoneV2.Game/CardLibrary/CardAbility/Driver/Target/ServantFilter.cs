using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target
{
    internal class ServantFilter : ITarget
    {
        public Func<BaseBiology, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<BaseBiology, bool>(c => c != null && c.CardType == CardType.随从 && c.CardInGameCode == actionParameter.SecondaryCard.CardInGameCode);
        }
    }
}
