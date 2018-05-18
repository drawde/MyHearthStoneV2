using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Trigger;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    public class BiologyHurtObserverDriver<G, F> : BaseDriver<G, F>, ICapture<F, AnyHurtEvent> where G : IGameAction where F : ICardLocationFilter
    {
        //public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.随从受伤 };

        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(AnyHurtEvent);
        }
    }
}
