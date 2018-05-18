using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.CardLibrary;

namespace MyHearthStoneV2.Game.Widget.Condition.Assert.Injured
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
