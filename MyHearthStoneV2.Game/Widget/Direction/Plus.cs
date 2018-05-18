using MyHearthStoneV2.Game.Widget.Number;
namespace MyHearthStoneV2.Game.Widget.Direction
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
