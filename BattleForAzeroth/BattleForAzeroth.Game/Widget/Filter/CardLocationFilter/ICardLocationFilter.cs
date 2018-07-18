using BattleForAzeroth.Game.CardLibrary;

namespace BattleForAzeroth.Game.Widget.Filter.CardLocationFilter
{
    public interface ICardLocationFilter: IGameWidgetCache
    {
        bool Filter(Card card);
    }
}
