using MyHearthStoneV2.Common.Util;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity
{
    /// <summary>
    /// 随机数
    /// </summary>
    /// <typeparam name="Min">最小数</typeparam>
    /// <typeparam name="Max">最大数</typeparam>
    internal class RandomQuantity<Min, Max> : IQuantity where Min : IQuantity where Max : IQuantity
    {
        int IQuantity.Quantity { get; set; } = RandomUtil.CreateRandomInt(GameActivator<Min>.CreateInstance().Quantity, GameActivator<Max>.CreateInstance().Quantity);
    }
}
