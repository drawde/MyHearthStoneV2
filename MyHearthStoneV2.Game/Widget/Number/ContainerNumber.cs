using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Widget.Number
{
    public class ContainerNumber : INumber
    {
        public int Number { get; set; }
        public bool NoCache { get; set; } = true;

        public int GetNumber(BaseActionParameter actionParameter)
        {
            return actionParameter.CNTR_Number ?? 0;
        }
    }
}
