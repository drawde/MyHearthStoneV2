using BattleForAzeroth.Game.CardLibrary;

namespace BattleForAzeroth.Game.Widget.Filter.CardLocationFilter
{
    public class InHandFilter : ICardLocationFilter
    {
        public bool NoCache { get; set; } = true;
        public bool Filter(Card card)
        {
            return card.CardLocation == CardLocation.手牌;
        }
    }
}
