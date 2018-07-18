using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Trigger;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver
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
