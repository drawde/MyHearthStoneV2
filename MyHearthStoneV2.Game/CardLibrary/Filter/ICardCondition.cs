using System;

namespace MyHearthStoneV2.Game.CardLibrary.Filter
{
    public interface ICardCondition
    {
        Func<Card, bool> Filter();
    }
}
