using BattleForAzeroth.Game.Widget.Number;
namespace BattleForAzeroth.Game.Widget.Direction
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
