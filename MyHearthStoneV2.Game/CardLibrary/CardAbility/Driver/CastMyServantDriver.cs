using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 己方随从入场驱动器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CastMyServantDriver<T, F> : BaseDriver<T>, ICapture<F, CastServantEvent> where T : IGameAction where F : ICardFilter
    {
        //public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方随从入场 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            Activator.CreateInstance<T>().Action(actionParameter);
            return null;
        }

        public bool TryCapture(Card card, IEvent @event)
        {
            ICardFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(CastServantEvent) && @event.EventCard.IsFirstPlayerCard == card.IsFirstPlayerCard;
        }
    }
}
