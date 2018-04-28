using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.PlayCard
{
    public class MainPlayerPlayCardDriver<T, F> : BaseDriver<T, F>, ICapture<F, MainPlayerPlayCardEvent> where T : IGameAction where F : ICardLocationFilter
    {    
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(MainPlayerPlayCardEvent) && @event.Parameter.UserContext.IsActivation;
        }
    }
}
