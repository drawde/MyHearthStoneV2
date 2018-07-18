using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Condition.Assert.ActionPrameter.SecondaryCard
{
    public class SecondaryCardIsHero : IAssert
    {
        public bool True(ActionParameter actionParameter)
        {
            return actionParameter.SecondaryCard.CardType == CardType.英雄;
        }
    }
}
