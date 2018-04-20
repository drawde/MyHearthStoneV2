namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity
{
    /// <summary>
    /// 数量
    /// </summary>
    public interface IQuantity: IGameCache
    {
        int Quantity { get; set; }
    }
}
