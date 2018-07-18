using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Player;
using BattleForAzeroth.Game.Context;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.PlayCard
{
    public class PrimaryPlayerPlayCardDriver<T, F> : BaseDriver<T, F>, ICapture<F, PrimaryPlayerPlayCardEvent> where T : IGameAction where F : ICardLocationFilter
    {    
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(PrimaryPlayerPlayCardEvent) && @event.Parameter.GameContext.IsThisActivationUserCard(card);
        }
    }
}
