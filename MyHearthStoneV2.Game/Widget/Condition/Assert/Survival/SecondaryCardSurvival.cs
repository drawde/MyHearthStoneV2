using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Widget.Condition.Assert.Survival
{
    public class SecondaryCardSurvival : ISurvival
    {
        public bool True(BaseActionParameter actionParameter)
        {
            var biology = actionParameter.SecondaryCard as BaseBiology;
            return biology.Life > 0 && biology.IsDeathing == false;
        }
    }
}
