using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Condition.Assert.Survival
{
    public class SecondaryCardSurvival : ISurvival
    {
        public bool True(ActionParameter actionParameter)
        {
            var biology = actionParameter.SecondaryCard as BaseBiology;
            return biology.Life > 0 && biology.IsDeathing == false;
        }
    }
}
