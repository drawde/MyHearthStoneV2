using BattleForAzeroth.Game.Util;
using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
using System.Linq;

namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter
{
    /// <summary>
    /// 随机选择场上目标
    /// </summary>
    public class DeskCardRandomFilter : IParameterFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            var targets = actionParameter.GameContext.DeskCards.GetAllBiology().ToList();
            return new Func<Card, bool>(c => c.CardInGameCode == targets[RandomUtil.CreateRandomInt(0, targets.Count() - 1)].CardInGameCode);
        }
    }
}
