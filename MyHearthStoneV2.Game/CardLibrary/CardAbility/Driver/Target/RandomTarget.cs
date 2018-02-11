using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target
{
    /// <summary>
    /// 随机选择场上目标
    /// </summary>
    internal class RandomTarget : ITarget
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            var targets = actionParameter.GameContext.DeskCards.GetAllBiology();
            return new Func<Card, bool>(c => c.CardInGameCode == targets[RandomUtil.CreateRandomInt(0, targets.Count - 1)].CardInGameCode);
        }
    }
}
