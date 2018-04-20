using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Trigger;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    public class ServantHurtObserverDriver<G, F> : BaseDriver<G, F>, ICapture<F, AnyServantHurtEvent> where G : IGameAction where F : ICardLocationFilter
    {
        //public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.随从受伤 };

        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(AnyServantHurtEvent);
        }
    }
}
