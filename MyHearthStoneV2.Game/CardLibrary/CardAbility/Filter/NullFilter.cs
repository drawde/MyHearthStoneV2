namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter
{
    public class NullFilter : ICardLocationFilter
    {
        public bool NoCache { get; set; } = false;
        public CardLocation CardLocation { get; set; } = CardLocation.不限;

        public bool Filter(Card card)
        {
            return true;
        }
    }
}
