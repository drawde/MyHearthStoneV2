using MyHearthStoneV2.Game.Parameter;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.DynamicNumber
{
    public class GetDynamicNumber<F> : IDynamicNumber where F : ICardFilter
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; }

        public int GetNumber(BaseActionParameter actionParameter)
        {
            Number = actionParameter.GameContext.AllCard.Count(System.Activator.CreateInstance<F>().Filter());
            return Number;
        }
    }
}
