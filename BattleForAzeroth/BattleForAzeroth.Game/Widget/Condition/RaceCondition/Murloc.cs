namespace BattleForAzeroth.Game.Widget.Condition.RaceCondition
{
    public class Murloc : IRace
    {
        public Race Race { get; set; } = Race.鱼人;
        public bool NoCache { get; set; } = true;
    }
}
