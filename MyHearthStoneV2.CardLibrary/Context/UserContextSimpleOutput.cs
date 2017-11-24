using MyHearthStoneV2.CardLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Context
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
        public List<Card> DeskCards { get; set; }

        /// <summary>
        /// 玩家开场摸的牌
        /// </summary>
        public int InitCards { get; set; }
    }
}
