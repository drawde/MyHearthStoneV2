using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant
{
    /// <summary>
    /// 随机选择主卡方场上的随从
    /// </summary>
    internal class RandomMainServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            var targets = actionParameter.GameContext.DeskCards.GetDeskServantsByIsFirst(user.IsFirst);
            return new Func<Card, bool>(c => c.CardInGameCode == targets[RandomUtil.CreateRandomInt(0, targets.Count - 1)].CardInGameCode);
        }
    }
}
