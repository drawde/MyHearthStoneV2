using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Widget;
using System;

namespace MyHearthStoneV2.Game.Widget.Filter
{
    public interface ICardCondition
    {
        Func<Card, bool> Filter();
    }
}
