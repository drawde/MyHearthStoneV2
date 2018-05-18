using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Widget.Condition.RaceCondition;
using MyHearthStoneV2.Game.CardLibrary.Servant;

namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant
{
    public class RaceFilter<RaceEnum> : IServantFilter where RaceEnum : IRace
    {
        public Func<Card, bool> Filter(BaseActionParameter baseActionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && (c as BaseServant).Race == GameActivator<RaceEnum>.CreateInstance().Race);
        }
    }
}
