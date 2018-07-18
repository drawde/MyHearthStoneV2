using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Condition.Assert.Survival
{
    public class PrimaryCardSurvival : ISurvival
    {
        public bool True(ActionParameter actionParameter)
        {
            var biology = actionParameter.PrimaryCard as BaseBiology;
            return biology.Life > 0 && biology.IsDeathing == false;
        }
    }
}
