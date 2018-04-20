using System;

namespace MyHearthStoneV2.Game.CardLibrary.Filter
{
    public interface ICardFilter//<C> where C: ICardCondition
    {
        Func<Card, bool> Filter();
    }
}
