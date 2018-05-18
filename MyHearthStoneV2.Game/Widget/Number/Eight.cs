using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Widget.Number
{
    public class Eight : INumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; } = 8;

        public int GetNumber(BaseActionParameter actionParameter) => 8;
    }
}
