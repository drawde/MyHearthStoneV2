using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game
{
    /// <summary>
    /// 当前用户的牌
    /// </summary>
    public class UserCards
    {
        /// <summary>
        /// 当前回合的费用
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// 是否先手
        /// </summary>
        public bool IsFirst { get; set; }

        /// <summary>
        /// 是否是当前回合
        /// </summary>
        public bool IsActivation { get; set; }

        public HS_Users User { get; set; }

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
        /// 开局时是否换了牌
        /// </summary>
        public bool SwitchDone { get; set; }
    }
}
