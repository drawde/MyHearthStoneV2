namespace BattleForAzeroth.Game.Widget.Number
{
    public class ONE : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 1;
        public int GetNumber(Parameter.ActionParameter actionParameter)
        {
            return 1;
        }
    }
}
