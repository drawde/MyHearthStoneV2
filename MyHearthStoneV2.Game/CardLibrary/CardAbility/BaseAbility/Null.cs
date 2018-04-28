using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Null : ICardAbility
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
