using MyHearthStoneV2.Game.CardLibrary;
using System;

namespace MyHearthStoneV2.Game.Widget.Filter.Servant
{
    public class NullServantFilter : IServantCardFilter
    {
        public Func<Card, bool> Filter()
        {
            return new Func<Card, bool>(c => true);
        }
    }
}
