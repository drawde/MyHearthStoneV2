namespace BattleForAzeroth.Game.Widget.Number
{
    public class Seven : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 7;
        public int GetNumber(Parameter.ActionParameter actionParameter)
        {
            return 7;
        }
    }
}
