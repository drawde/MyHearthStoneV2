using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Assert.Injured
{
    public class SecondaryCardIsInjured : IAssert
    {
        public bool True(BaseActionParameter actionParameter)
        {
            BaseBiology baseBiology = actionParameter.SecondaryCard as BaseBiology;
            return baseBiology.Life < baseBiology.BuffLife;
        }
    }
}
