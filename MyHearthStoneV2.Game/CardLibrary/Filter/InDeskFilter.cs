using System;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Filter
{
    internal class InDeskFilter : ICardFilter
    {
        public bool Filter(Card card)
        {
            return card.CardLocation == CardLocation.场上;
        }
    }
}
