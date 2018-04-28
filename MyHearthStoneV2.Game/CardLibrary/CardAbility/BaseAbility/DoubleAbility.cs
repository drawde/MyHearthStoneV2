using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class DoubleAbility<First, Second> : ICardAbility where First : ICardAbility where Second : ICardAbility
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Activator.CreateInstance<First>().Action(actionParameter);
            Activator.CreateInstance<Second>().Action(actionParameter);
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}