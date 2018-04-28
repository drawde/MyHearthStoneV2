namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number
{
    public class Nine : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 9;
        public int GetNumber(Parameter.BaseActionParameter actionParameter)
        {
            return 9;
        }
    }
}
