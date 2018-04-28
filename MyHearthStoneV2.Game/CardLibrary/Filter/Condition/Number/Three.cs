namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number
{
    public class Three : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 3;
        public int GetNumber(Parameter.BaseActionParameter actionParameter)
        {
            return 3;
        }
    }
}
