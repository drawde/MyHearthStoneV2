namespace BattleForAzeroth.Game.Widget.Condition.Pick
{
    public class LimitPick : IPickType
    {
        public bool NoCache { get; set; } = false;
        public PickType PickType { get; set; } = PickType.指定;
    }
}
