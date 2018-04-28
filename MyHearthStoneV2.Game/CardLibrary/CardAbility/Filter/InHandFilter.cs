namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter
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
