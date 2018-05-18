using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.PlayCard
{
    public class PrimaryPlayerPlayCardDriver<T, F> : BaseDriver<T, F>, ICapture<F, PrimaryPlayerPlayCardEvent> where T : IGameAction where F : ICardLocationFilter
    {    
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(PrimaryPlayerPlayCardEvent) && @event.Parameter.UserContext.IsActivation;
        }
    }
}
