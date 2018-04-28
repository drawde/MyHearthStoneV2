using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;
using MyHearthStoneV2.Game.Event;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 修改手牌的费用
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    /// <typeparam name="Q"></typeparam>
    /// <typeparam name="D"></typeparam>
    public class UpdateCost<UC, TAG, Q, D> : ICardAbility where UC : IUserContextFilter where TAG : IFilter where Q : INumber where D : IDirection
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            D direction = Activator.CreateInstance<D>();
            UC uc = Activator.CreateInstance<UC>();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            foreach (UserContext user in users)
            {
                foreach (BaseBiology biology in user.HandCards.Where(Activator.CreateInstance<TAG>().Filter(actionParameter)))
                {
                    int Number = direction.SetNumber(GameActivator<Q>.CreateInstance());
                    biology.Cost += Number;
                }
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
