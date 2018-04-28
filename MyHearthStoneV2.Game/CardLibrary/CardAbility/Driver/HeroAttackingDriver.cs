using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Hero;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    public class HeroAttackingDriver<G, F> : BaseDriver<G, F>, ICapture<F, HeroAttackingEvent> where G : IGameAction where F : ICardLocationFilter
    {
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(HeroAttackingEvent);
        }
    }
}
