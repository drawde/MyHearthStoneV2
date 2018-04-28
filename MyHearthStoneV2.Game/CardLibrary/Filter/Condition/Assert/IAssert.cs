using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Assert
{
    public interface IAssert
    {
        bool True(BaseActionParameter actionParameter);
    }
}
