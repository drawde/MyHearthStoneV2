namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.RarityCondition
{
    public interface IRarity : IGameCache
    {
        Rarity Rarity { get; set; }
    }
}
