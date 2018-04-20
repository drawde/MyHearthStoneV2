using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction
{
    /// <summary>
    /// 负数
    /// </summary>
    public class Minus : IDirection
    {
        public int SetQuantity(IQuantity quantity)
        {
            return quantity.Quantity * -1;
        }
    }
}
