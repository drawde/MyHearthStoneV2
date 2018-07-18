using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter;
using System.Linq;

namespace BattleForAzeroth.Game.Widget.Number.DynamicNumber
{
    public class GetDynamicNumber<F> : IDynamicNumber where F : ICardFilter
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; }

        public int GetNumber(ActionParameter actionParameter)
        {
            Number = actionParameter.GameContext.AllCard.Count(System.Activator.CreateInstance<F>().Filter(actionParameter));
            return Number;
        }
    }
}
