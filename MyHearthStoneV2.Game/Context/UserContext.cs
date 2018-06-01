using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Model.CustomModels;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.Context
{
    /// <summary>
    /// 当前用户上下文
    /// </summary>
    public class UserContext: BaseUserContext
    {


        public CUsers User { get; set; }

        /// <summary>
        /// 玩家所有的牌
        /// </summary>
        public List<Card> AllCards { get; set; }

        /// <summary>
        /// 玩家的手牌
        /// </summary>
        public IEnumerable<Card> HandCards => AllCards.Where(c => c.CardLocation == CardLocation.手牌).OrderByDescending(c => c.Sort);

        /// <summary>
        /// 玩家牌库的牌
        /// </summary>
        public IEnumerable<Card> StockCards => AllCards.Where(c => c.CardLocation == CardLocation.牌库).OrderByDescending(c => c.Sort);

        /// <summary>
        /// 玩家开场摸的牌
        /// </summary>
        public IEnumerable<Card> InitCards => AllCards.Where(c => c.CardLocation == CardLocation.InitCard);

        /// <summary>
        /// 玩家坟场的牌
        /// </summary>
        public IEnumerable<Card> GraveyardCards => AllCards.Where(c => c.CardLocation == CardLocation.坟场);

        /// <summary>
        /// 疲劳值
        /// </summary>
        public int FatigueValue { get; set; }

    }
}
