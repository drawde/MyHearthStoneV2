using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.Capture
{
    /// <summary>
    /// 对游戏事件的捕获
    /// </summary>
    public interface ICapture<Filter, Event> where Filter : ICardLocationFilter where Event : IEvent
    {
        bool TryCapture(Card card, IEvent @event);
    }
}
