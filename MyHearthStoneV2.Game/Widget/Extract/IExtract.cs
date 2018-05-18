using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;

namespace MyHearthStoneV2.Game.Widget.Extract
{
    public interface IExtract<F> where F : IParameterFilter
    {
        string Extract(BaseActionParameter actionParameter);
    }
}
