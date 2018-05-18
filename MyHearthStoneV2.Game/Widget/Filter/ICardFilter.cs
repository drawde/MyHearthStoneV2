using MyHearthStoneV2.Game.CardLibrary;
using System;

namespace MyHearthStoneV2.Game.Widget.Filter
{
    public interface ICardFilter//<C> where C: ICardCondition
    {
        Func<Card, bool> Filter();
    }
}
