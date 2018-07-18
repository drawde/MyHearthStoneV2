using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Number.DynamicNumber
{
    public class DynamicDoubleNumber<Q> : IDynamicNumber where Q : IDynamicNumber
    {
        public bool NoCache { get; set; } = false;
        public int Number { get; set; }

        public int GetNumber(ActionParameter actionParameter)
        {            
            Q q = System.Activator.CreateInstance<Q>();
            Number = q.GetNumber(actionParameter) * 2;
            return Number;
        }
    }
}
