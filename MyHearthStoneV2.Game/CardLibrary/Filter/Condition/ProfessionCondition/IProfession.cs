namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.ProfessionCondition
{
    public interface IProfession : IGameCache
    {
        Game.Profession Profession { get; set; }
    }
}
