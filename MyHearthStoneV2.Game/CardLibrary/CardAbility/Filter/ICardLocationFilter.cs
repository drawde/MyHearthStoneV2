using System;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter
{
    public interface ICardLocationFilter: IGameCache
    {
        bool Filter(Card card);
    }
}
