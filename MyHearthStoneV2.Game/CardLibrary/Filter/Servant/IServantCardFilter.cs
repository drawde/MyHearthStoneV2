using MyHearthStoneV2.Game.CardLibrary.Filter.Condition;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Servant
{
    public interface IServantCardFilter : ICardFilter//<C> where C : ServantCondition<CostFilter<IQuantity>>
    {
        //public Func<Card, bool> Filter()
        //{
        //    return new Func<Card, bool>(c => c.CardType == CardType.随从);
        //}
    }
}
