using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.GameProcess;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    public class MyTurnEndDriver<T, F> : BaseDriver<T, F>, ICapture<F, MyTurnEndEvent> where T : IGameAction where F : ICardLocationFilter
    {
        //public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合结束 };

        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(MyTurnEndEvent) && @event.Parameter.UserContext.IsActivation;
        }
    }
}
