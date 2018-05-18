using System;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Container
{
    public class NumberContainer<Ability, Number> : ICardAbility, IContainer where Ability : ICardAbility where Number : INumber
    {

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Ability ability = Activator.CreateInstance<Ability>();
            actionParameter.CNTR_Number = Activator.CreateInstance<Number>().GetNumber(actionParameter);
            var res = ability.Action(actionParameter);
            actionParameter.CNTR_Number = null;
            return res;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
