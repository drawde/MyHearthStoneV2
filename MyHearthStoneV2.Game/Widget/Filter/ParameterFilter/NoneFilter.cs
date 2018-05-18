using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.CardLibrary;
namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter
{
    public class NoneFilter : IParameterFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            return new Func<Card, bool>(c => c != null);
        }
    }
}
