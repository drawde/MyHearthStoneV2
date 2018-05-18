using System.Collections.Generic;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Number;

namespace MyHearthStoneV2.Game.Widget.Filter.PickCard
{
    public class RandomCardPickFilter<NUM> : ICardPickFilter where NUM : INumber
    {
        public IEnumerable<Card> Filter(IList<Card> cards, BaseActionParameter baseActionParameter)
        {
            int num = GameActivator<NUM>.CreateInstance().GetNumber(baseActionParameter);
            num = num > cards.Count ? cards.Count : num;
            List<int> indexs = RandomUtil.CreateRandomInt(0, cards.Count - 1, num);
            List<Card> resultCards = new List<Card>();
            foreach (int i in indexs)
            {
                resultCards.Add(cards[i]);
            }
            return resultCards;
        }
    }
}
