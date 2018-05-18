namespace MyHearthStoneV2.Game.Widget.Number
{
    public class Zero : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 0;
        public int GetNumber(Parameter.BaseActionParameter actionParameter)
        {
            return 0;
        }
    }
}
