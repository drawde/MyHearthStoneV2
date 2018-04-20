using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Trigger;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 每当己方随从受到伤害驱动器
    /// </summary>
    /// <typeparam name="G"></typeparam>
    public class MyServantHurtObserverDriver<G, F> : BaseDriver<G, F>, ICapture<F, MyServantHurtEvent> where G : IGameAction where F : ICardLocationFilter
    {
        //public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从受到伤害后 };
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(MyServantHurtEvent) && @event.EventCard.IsFirstPlayerCard == card.IsFirstPlayerCard;
        }
    }
}
