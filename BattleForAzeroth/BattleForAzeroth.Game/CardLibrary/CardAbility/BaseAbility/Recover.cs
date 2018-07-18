using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.CardLibrary.CardAction.Player;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
using System;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 将场上的牌返回到手牌
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    public class Recover<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                UserContext user = actionParameter.GameContext.GetUserContextByMyCard(biology);
                var para = new ActionParameter()
                {
                    ReturnCount = 1,
                    GameContext = actionParameter.GameContext,
                    UserContext = user,
                    PrimaryCard = actionParameter.SecondaryCard
                };
                new ReturnCardToHandAction().Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
