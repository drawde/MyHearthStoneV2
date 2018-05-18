using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using System;

namespace MyHearthStoneV2.Game.Widget.Filter.Servant
{
    public class AssignServantFilter<S> : IServantCardFilter where S : BaseServant
    {
        public Func<Card, bool> Filter()
        {
            S servant = Activator.CreateInstance<S>();
            return new Func<Card, bool>(c => c.CardType == CardType.随从 && c.GetType() == servant.GetType());
        }
    }
}
