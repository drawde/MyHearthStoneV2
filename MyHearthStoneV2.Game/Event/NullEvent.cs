using System;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Event
{
    public class NullEvent : IEvent
    {
        public BaseActionParameter Parameter { get; set; }
        public Card EventCard { get; set; }

        public void Settlement()
        {
        }
    }
}
