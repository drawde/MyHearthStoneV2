using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction
{
    public interface IDirection : IGameCache
    {
        int SetQuantity(IQuantity quantity);
    }
}
