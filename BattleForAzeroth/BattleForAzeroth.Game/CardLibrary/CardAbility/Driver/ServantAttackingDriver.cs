using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Servant;
using BattleForAzeroth.Game.Event.Trigger;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver
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
