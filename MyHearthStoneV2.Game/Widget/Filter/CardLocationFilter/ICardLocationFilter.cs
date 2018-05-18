using MyHearthStoneV2.Game.CardLibrary;

namespace MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter
{
    public interface ICardLocationFilter: IGameCache
    {
        bool Filter(Card card);
    }
}
