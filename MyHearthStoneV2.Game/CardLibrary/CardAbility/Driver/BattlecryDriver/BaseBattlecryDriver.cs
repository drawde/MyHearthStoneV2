﻿using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Event.Player;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver
{
    public class BaseBattlecryDriver<G, F> : BaseDriver<G, F>, ICapture<F, CastServantEvent> where G : IGameAction where F : ICardLocationFilter
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.战吼;
        public override bool TryCapture(Card card, IEvent @event)
        {
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == typeof(CastServantEvent) && @event.EventCard.IsFirstPlayerCard == card.IsFirstPlayerCard;
        }
    }
}
