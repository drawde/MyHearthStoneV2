using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Aura;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 光环驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AuraDriver<T, F, E> : BaseDriver<T, F>, ICapture<F, E> where T : IAura where F : ICardLocationFilter where E : IEvent
    {
        public Card AuraCard { get; set; }
        //private ICardLocationFilter filter = GameActivator<F>.CreateInstance();
        public AuraDriver(Card auraCard)
        {
            auraCard = AuraCard;
        }
        public override IActionOutputParameter Action(ActionParameter actionParameter)
        {
            IAura aura = (IAura)Activator.CreateInstance(typeof(T), AuraCard);
            aura.LocationFilter = GameActivator<F>.CreateInstance();
            return aura.Action(actionParameter);
        }
        public override bool TryCapture(Card card, IEvent @event)
        {            
            return GameActivator<F>.CreateInstance().Filter(card) && @event.GetType() == typeof(E) && @event.EventCard.IsFirstPlayerCard == card.IsFirstPlayerCard;
        }
    }
}
