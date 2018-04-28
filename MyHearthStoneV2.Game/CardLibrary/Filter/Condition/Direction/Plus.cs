using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction
{
    /// <summary>
    /// 正数
    /// </summary>
    public class Plus: IDirection
    {
        public int SetNumber(INumber Number)
        {
            return Number.Number;
        }
    }
}
