using BattleForAzeroth.Game.CardLibrary;

namespace BattleForAzeroth.Game.Widget.Filter.CardLocationFilter
{
    public class InParachuteFilter : ICardLocationFilter
    {
        public bool NoCache { get; set; } = true;
        public bool Filter(Card card)
        {
            return card.CardLocation == CardLocation.降落伞;
        }
    }
}
