namespace MyHearthStoneV2.Game.Widget.Number
{
    public class Six : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 6;
        public int GetNumber(Parameter.BaseActionParameter actionParameter)
        {
            return 6;
        }
    }
}
