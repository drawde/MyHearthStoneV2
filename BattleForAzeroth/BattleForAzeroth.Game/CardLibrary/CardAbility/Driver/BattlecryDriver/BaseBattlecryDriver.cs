using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Event.Player;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.BattlecryDriver
{
    public class BaseBattlecryDriver<G, F> : BaseDriver<G, F>, ICapture<F, BattlecryEvent> where G : IGameAction where F : ICardLocationFilter
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.战吼;
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(BattlecryEvent) && @event.EventCard.IsFirstPlayerCard == card.IsFirstPlayerCard;
        }
    }
}
