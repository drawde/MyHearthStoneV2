using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 光环驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AuraDriver<T, F, E> : BaseDriver<T, F>, ICapture<F, E> where T : IAura where F : ICardLocationFilter where E : IEvent
    {
        public Card AuraCard { get; set; }
        private ICardLocationFilter filter = GameActivator<F>.CreateInstance();
        public AuraDriver(Card auraCard)
        {
            auraCard = AuraCard;
        }
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            IAura aura = (IAura)Activator.CreateInstance(typeof(T), AuraCard);
            aura.LocationFilter = filter;
            return aura.Action(actionParameter);
        }
        public override bool TryCapture(Card card, IEvent @event)
        {            
            return filter.Filter(card) && @event.GetType() == typeof(E) && @event.EventCard.IsFirstPlayerCard == card.IsFirstPlayerCard;
        }
    }
}
