using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.Model.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Context
{
    /// <summary>
    /// 用户上下文（用于输出）
    /// </summary>
    public class UserContextOutput: BaseUserContext
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
        /// 玩家场上的牌
        /// </summary>
        public List<Card> DeskCards { get; set; }

        /// <summary>
        /// 玩家开场摸的牌
        /// </summary>
        public List<Card> InitCards { get; set; }        
    }
}
