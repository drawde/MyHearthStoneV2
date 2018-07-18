using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Event;
using System;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 修改手牌的费用
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    /// <typeparam name="Q"></typeparam>
    /// <typeparam name="D"></typeparam>
    public class UpdateCost<UC, TAG, Q, D> : ICardAbility where UC : IUserContextFilter where TAG : IParameterFilter where Q : INumber where D : IDirection
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
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
