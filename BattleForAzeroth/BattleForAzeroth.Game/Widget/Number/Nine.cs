namespace BattleForAzeroth.Game.Widget.Number
{
    public class Nine : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 9;
        public int GetNumber(Parameter.ActionParameter actionParameter)
        {
            return 9;
        }
    }
}
