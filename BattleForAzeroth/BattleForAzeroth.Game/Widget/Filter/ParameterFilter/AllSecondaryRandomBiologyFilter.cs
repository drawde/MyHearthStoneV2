using BattleForAzeroth.Game.Util;
using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.Context;
using System.Linq;
using BattleForAzeroth.Game.CardLibrary;
namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter
{
    public class AllSecondaryRandomBiologyFilter : IParameterFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            var targets = actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard).IsFirst).
                Where(c => c != null).ToList();
            return new Func<Card, bool>(c => c != null && c.CardInGameCode == targets[RandomUtil.CreateRandomInt(0, targets.Count - 1)].CardInGameCode);
        }
    }
}
