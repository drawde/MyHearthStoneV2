using MyHearthStoneV2.Game.CardLibrary;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.Context
{
    public class UserContextSimpleOutput: BaseUserContext
    {
        /// <summary>
        /// 玩家的手牌（用于输出对手的上下文）
        /// </summary>
        public int HandCards { get; set; }

        /// <summary>
        /// 玩家牌库的牌
        /// </summary>
        public int StockCards { get; set; }

        /// <summary>
        /// 玩家场上的牌
        /// </summary>
        public List<BaseBiology> DeskCards { get; set; }

        /// <summary>
        /// 玩家开场摸的牌
        /// </summary>
        public int InitCards { get; set; }
    }
}
