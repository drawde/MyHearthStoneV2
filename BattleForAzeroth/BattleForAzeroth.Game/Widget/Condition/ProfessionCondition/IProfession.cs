namespace BattleForAzeroth.Game.Widget.Condition.ProfessionCondition
{
    public interface IProfession : IGameWidgetCache
    {
        Game.Profession Profession { get; set; }
    }
}
