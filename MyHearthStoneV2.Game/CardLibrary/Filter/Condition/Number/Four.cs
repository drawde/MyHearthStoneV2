using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number
{
    public class Four : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 4;
        public int GetNumber(BaseActionParameter actionParameter)
        {
            return 4;
        }
    }
}
