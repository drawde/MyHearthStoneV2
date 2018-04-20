using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction
{
    /// <summary>
    /// 正数
    /// </summary>
    public class Plus: IDirection
    {
        public int SetQuantity(IQuantity quantity)
        {
            return quantity.Quantity;
        }
    }
}
