using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class DoubleAbility<First, Second> : ICardAbility where First : ICardAbility where Second : ICardAbility
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            Activator.CreateInstance<First>().Action(actionParameter);
            Activator.CreateInstance<Second>().Action(actionParameter);
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}