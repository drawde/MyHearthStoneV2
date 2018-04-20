using MyHearthStoneV2.Common.Util;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity
{
    /// <summary>
    /// 随机数
    /// </summary>
    /// <typeparam name="Min">最小数</typeparam>
    /// <typeparam name="Max">最大数</typeparam>
    public class RandomQuantity<Min, Max> : IQuantity where Min : IQuantity where Max : IQuantity
    {
        int IQuantity.Quantity { get; set; } = RandomUtil.CreateRandomInt(GameActivator<Min>.CreateInstance().Quantity, GameActivator<Max>.CreateInstance().Quantity);
    }
}
