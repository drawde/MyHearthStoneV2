using System;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Container
{
    public class NumberContainer<Ability, Number> : ICardAbility, IContainer where Ability : ICardAbility where Number : INumber
    {

        public IActionOutputParameter Action(ActionParameter actionParameter)
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
