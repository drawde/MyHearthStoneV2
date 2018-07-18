namespace BattleForAzeroth.Game.Widget.Number
{
    public class Zero : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 0;
        public int GetNumber(Parameter.ActionParameter actionParameter)
        {
            return 0;
        }
    }
}
