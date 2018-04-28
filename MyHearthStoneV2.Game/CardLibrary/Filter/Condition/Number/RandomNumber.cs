using MyHearthStoneV2.Common.Util;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number
{
    /// <summary>
    /// 随机数
    /// </summary>
    /// <typeparam name="Min">最小数</typeparam>
    /// <typeparam name="Max">最大数</typeparam>
    public class RandomNumber<Min, Max> : INumber where Min : INumber where Max : INumber
    {
        public bool NoCache { get; set; } = true;
        public int Number { get; set; }
        public int GetNumber(Parameter.BaseActionParameter actionParameter)
        {
            return RandomUtil.CreateRandomInt(GameActivator<Min>.CreateInstance().GetNumber(actionParameter), GameActivator<Max>.CreateInstance().GetNumber(actionParameter));
        }
    }
}
