using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Assert.ActionPrameter.SecondaryCard
{
    public class SecondaryCardIsHero : IAssert
    {
        public bool True(BaseActionParameter actionParameter)
        {
            return actionParameter.SecondaryCard.CardType == CardType.英雄;
        }
    }
}
