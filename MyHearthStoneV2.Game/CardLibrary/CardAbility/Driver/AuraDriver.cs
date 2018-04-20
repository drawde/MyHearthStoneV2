using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;
using System;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 光环驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AuraDriver<T, CT, F> : BaseDriver<T, F>, ICapture<F, NullEvent> where T : IGameAction where CT : List<SpellCardAbilityTime> where F : ICardLocationFilter
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.光环;

        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = Activator.CreateInstance<CT>();

        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(NullEvent);
        }
    }
}
