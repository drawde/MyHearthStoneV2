using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;
using MyHearthStoneV2.Game.Event.Trigger;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 受伤
    /// </summary>
    /// <typeparam name="G"></typeparam>
    public class HurtDriver<T, F> : BaseDriver<T, F>, ICapture<F, HurtEvent> where T : IGameAction where F : ICardLocationFilter
    {
        //public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.受伤 };
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(HurtEvent);
        }
    }
}
