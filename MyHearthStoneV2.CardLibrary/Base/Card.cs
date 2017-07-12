using MyHearthStoneV2.CardEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Base
{
    /// <summary>
    /// 卡牌基类接口
    /// </summary>
    public abstract class Card
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
        public string GameID { get; set; }

        /// <summary>
        /// 卡牌持有者
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 卡牌描述
        /// </summary>
        public string Describe { get; }
        /// <summary>
        /// 稀有程度
        /// </summary>
        public Rarity Rare { get; }

        public CardLocation CardLocation { get; set; }
    }
}
