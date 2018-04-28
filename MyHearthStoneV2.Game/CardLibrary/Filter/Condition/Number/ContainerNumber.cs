using System;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Container;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number
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
