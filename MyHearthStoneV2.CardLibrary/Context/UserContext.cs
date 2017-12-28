using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Model.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Context
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
        public List<Card> HandCards { get; set; }

        /// <summary>
        /// 玩家牌库的牌
        /// </summary>
        public List<Card> StockCards { get; set; }

        /// <summary>
        /// 玩家场上的牌
        /// </summary>
        public List<Card> DeskCards { get; set; }

        /// <summary>
        /// 玩家开场摸的牌
        /// </summary>
        public List<Card> InitCards { get; set; }

        /// <summary>
        /// 玩家坟场的牌
        /// </summary>
        public List<Card> GraveyardCards { get; set; } = new List<Card>();


        /// <summary>
        /// 疲劳值
        /// </summary>
        public int FatigueValue { get; set; }

        
    }
}
