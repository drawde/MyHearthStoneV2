using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Servant;
using MyHearthStoneV2.Game.Event.Trigger;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    public class ServantAttackingDriver<G, F> : BaseDriver<G, F>, ICapture<F, ServantAttackingEvent> where G : IGameAction where F : ICardLocationFilter
    {
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(ServantAttackingEvent);
        }
    }
}
