namespace BattleForAzeroth.Game.Widget.Number
{
    public class Two : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 2;
        public int GetNumber(Parameter.ActionParameter actionParameter)
        {
            return 2;
        }
    }
}
