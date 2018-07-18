using System;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Event
{
    public class NullEvent : IEvent
    {
        public ActionParameter Parameter { get; set; }
        public Card EventCard { get; set; }

        public void Settlement()
        {
        }
    }
}
