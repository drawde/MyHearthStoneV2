using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.CardLibrary;
namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter
{
    /// <summary>
    /// 随机选择场上目标
    /// </summary>
    public class DeskCardRandomFilter : IParameterFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            var targets = actionParameter.GameContext.DeskCards.GetAllBiology();
            return new Func<Card, bool>(c => c.CardInGameCode == targets[RandomUtil.CreateRandomInt(0, targets.Count - 1)].CardInGameCode);
        }
    }
}
