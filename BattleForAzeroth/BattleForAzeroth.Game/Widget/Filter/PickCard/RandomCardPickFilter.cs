using System.Collections.Generic;
using BattleForAzeroth.Game.Util;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Number;

namespace BattleForAzeroth.Game.Widget.Filter.PickCard
{
    public class RandomCardPickFilter<NUM> : ICardPickFilter where NUM : INumber
    {
        public IEnumerable<Card> Filter(IList<Card> cards, ActionParameter baseActionParameter)
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
