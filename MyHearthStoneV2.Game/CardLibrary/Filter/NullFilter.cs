namespace MyHearthStoneV2.Game.CardLibrary.Filter
{
    public class NullFilter : ICardFilter
    {
        public CardLocation CardLocation { get; set; } = CardLocation.不限;

        public bool Filter(Card card)
        {
            return true;
        }
    }
}
