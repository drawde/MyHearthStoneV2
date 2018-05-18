namespace MyHearthStoneV2.Game.Widget.Number
{
    public class Ten : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 10;
        public int GetNumber(Parameter.BaseActionParameter actionParameter)
        {
            return 10;
        }
    }
}
