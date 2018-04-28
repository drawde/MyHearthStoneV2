using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction
{
    /// <summary>
    /// 负数
    /// </summary>
    public class Minus : IDirection
    {
        public int SetNumber(INumber Number)
        {
            return Number.Number * -1;
        }
    }
}
