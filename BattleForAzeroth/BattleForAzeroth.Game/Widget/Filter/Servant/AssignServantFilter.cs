using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.Widget.Filter.Servant
{
    public class AssignServantFilter<S> : IServantCardFilter where S : BaseServant
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            S servant = Activator.CreateInstance<S>();
            return new Func<Card, bool>(c => c.CardType == CardType.随从 && c.GetType() == servant.GetType());
        }
    }
}
