using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Hero;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver
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
