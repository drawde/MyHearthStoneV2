using BattleForAzeroth.Game.Widget.Condition.Assert;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Assert<A, Y, N> : ICardAbility where Y : ICardAbility where N : ICardAbility where A: IAssert
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            A assert = Activator.CreateInstance<A>();
            Y yes = Activator.CreateInstance<Y>();
            N no = Activator.CreateInstance<N>();
            return assert.True(actionParameter) ? yes.Action(actionParameter) : no.Action(actionParameter);
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
