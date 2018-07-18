using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Widget.Condition.RaceCondition;
using BattleForAzeroth.Game.CardLibrary.Servant;

namespace BattleForAzeroth.Game.Widget.Filter.Servant
{
    public class RaceCardFilter<RaceEnum> : IServantCardFilter where RaceEnum : IRace
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && (c as BaseServant).Race == GameActivator<RaceEnum>.CreateInstance().Race);
        }
    }
}
