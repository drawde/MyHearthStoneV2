using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.Capture
{
    /// <summary>
    /// 对游戏事件的捕获
    /// </summary>
    public interface ICapture<Filter, Event> where Filter : ICardLocationFilter where Event : IEvent
    {
        bool TryCapture(Card card, IEvent @event);
    }
}
