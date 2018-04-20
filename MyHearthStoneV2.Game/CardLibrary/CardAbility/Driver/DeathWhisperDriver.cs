using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Ability;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 亡语驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DeathWhisperDriver<T, F> : BaseDriver<T, F>, ICapture<F, DeathWhisperEvent> where T : IGameAction where F : ICardLocationFilter
    {
        //public override AbilityType AbilityType => AbilityType.亡语;
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(DeathWhisperEvent);
        }
    }
}
