using System;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Filter
{
    public interface ICardFilter: IGameCache
    {
        bool Filter(Card card);
    }
}
