using BattleForAzeroth.Game.Widget.Number;
namespace BattleForAzeroth.Game.Widget.Direction
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
