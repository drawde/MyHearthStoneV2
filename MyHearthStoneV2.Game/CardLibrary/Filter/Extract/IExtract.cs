using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Extract
{
    public interface IExtract<F> where F : IFilter
    {
        string Extract(BaseActionParameter actionParameter);
    }
}
