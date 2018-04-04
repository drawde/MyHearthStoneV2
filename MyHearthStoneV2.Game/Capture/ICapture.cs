using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Filter;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.Capture
{
    /// <summary>
    /// 对游戏事件的捕获
    /// </summary>
    internal interface ICapture<Filter,Event> where Filter : ICardFilter where Event : IEvent
    {
        bool TryCapture(Card card, IEvent @event);
    }
}
