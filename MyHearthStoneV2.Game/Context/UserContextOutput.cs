using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.Context
{
    /// <summary>
    /// 用户上下文（用于输出）
    /// </summary>
    public class UserContextOutput : BaseUserContext
    {
        /// <summary>
        /// 玩家的手牌
        /// </summary>
        public List<Card> HandCards { get; set; }

        /// <summary>
        /// 玩家牌库的牌
        /// </summary>
        public int StockCards { get; set; }

        /// <summary>
        /// 玩家开场摸的牌
        /// </summary>
        public List<Card> InitCards { get; set; }

        public BaseHero Hero { get; set; }
    }
}
