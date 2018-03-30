using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter
{
    internal class NoneFilter : IFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null);
        }
    }
}
