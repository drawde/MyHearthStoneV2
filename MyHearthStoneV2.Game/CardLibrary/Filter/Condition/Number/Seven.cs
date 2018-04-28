namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number
{
    public class Seven : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 7;
        public int GetNumber(Parameter.BaseActionParameter actionParameter)
        {
            return 7;
        }
    }
}
