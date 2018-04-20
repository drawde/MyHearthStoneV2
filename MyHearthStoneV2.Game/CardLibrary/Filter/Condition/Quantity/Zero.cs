namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity
{
    public class Zero : IQuantity
    {
        int IQuantity.Quantity { get; set; } = 0;
    }
}
