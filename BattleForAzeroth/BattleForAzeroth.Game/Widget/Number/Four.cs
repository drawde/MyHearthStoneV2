using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Number
{
    public class Four : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 4;
        public int GetNumber(ActionParameter actionParameter)
        {
            return 4;
        }
    }
}
