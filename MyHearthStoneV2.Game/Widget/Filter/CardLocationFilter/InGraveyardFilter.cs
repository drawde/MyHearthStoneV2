using MyHearthStoneV2.Game.CardLibrary;

namespace MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter
{
    public class InGraveyardFilter : ICardLocationFilter
    {
        public bool NoCache { get; set; } = true;
        public bool Filter(Card card)
        {
            return card.CardLocation == CardLocation.场上;
        }
    }
}
