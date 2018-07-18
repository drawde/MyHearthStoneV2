using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Number
{
    public class DoubleNumber<Q> :INumber where Q :INumber
    {
        public bool NoCache { get; set; } = true;
        public int Number { get; set; } = GameActivator<Q>.CreateInstance().Number * 2;

        public int GetNumber(ActionParameter actionParameter)
        {
            Number = GameActivator<Q>.CreateInstance().GetNumber(actionParameter) * 2;
            return Number;
        }
    }
}
