using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Number
{
    public class Eight : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 8;

        public int GetNumber(ActionParameter actionParameter) => 8;
    }
}
