using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Number
{
    public class ContainerNumber : INumber
    {
        public int Number { get; set; }
        public bool NoCache { get; set; } = true;

        public int GetNumber(ActionParameter actionParameter)
        {
            return actionParameter.CNTR_Number ?? 0;
        }
    }
}
