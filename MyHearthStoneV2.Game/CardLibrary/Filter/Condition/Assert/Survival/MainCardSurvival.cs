using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Assert.Survival
{
    public class MainCardSurvival : ISurvival
    {
        public bool True(BaseActionParameter actionParameter)
        {
            var biology = actionParameter.MainCard as BaseBiology;
            return biology.Life > 0 && biology.IsDeathing == false;
        }
    }
}
