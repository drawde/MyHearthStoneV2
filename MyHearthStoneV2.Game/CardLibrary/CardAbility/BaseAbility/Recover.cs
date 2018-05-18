using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAction.Player;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Player;
using System;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 将场上的牌返回到手牌
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    public class Recover<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                UserContext user = actionParameter.GameContext.GetUserContextByMyCard(biology);
                ReturnCardToHandParameter para = new ReturnCardToHandParameter()
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
