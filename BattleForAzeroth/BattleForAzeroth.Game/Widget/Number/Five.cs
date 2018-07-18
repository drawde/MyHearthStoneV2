using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Number
{
    public class Five : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 5;
        public int GetNumber(ActionParameter actionParameter)
        {
            return 5;
        }
    }
}
