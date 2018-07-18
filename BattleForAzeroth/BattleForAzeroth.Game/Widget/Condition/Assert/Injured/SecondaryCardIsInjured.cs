using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.CardLibrary;

namespace BattleForAzeroth.Game.Widget.Condition.Assert.Injured
{
    public class SecondaryCardIsInjured : IAssert
    {
        public bool True(ActionParameter actionParameter)
        {
            BaseBiology baseBiology = actionParameter.SecondaryCard as BaseBiology;
            return baseBiology.Life < baseBiology.BuffLife;
        }
    }
}
