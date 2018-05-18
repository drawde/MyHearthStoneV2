namespace MyHearthStoneV2.Game.Widget.Condition.ProfessionCondition
{
    public interface IProfession : IGameCache
    {
        Game.Profession Profession { get; set; }
    }
}
