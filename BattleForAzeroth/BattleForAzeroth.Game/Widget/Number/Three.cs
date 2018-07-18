namespace BattleForAzeroth.Game.Widget.Number
{
    public class Three : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 3;
        public int GetNumber(Parameter.ActionParameter actionParameter)
        {
            return 3;
        }
    }
}
