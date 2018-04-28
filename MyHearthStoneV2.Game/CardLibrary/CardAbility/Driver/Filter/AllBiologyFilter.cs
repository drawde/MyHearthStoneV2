using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter
{
    public class AllBiologyFilter : IFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && (c.CardType == CardType.英雄 || c.CardType == CardType.随从));
        }
    }
}
