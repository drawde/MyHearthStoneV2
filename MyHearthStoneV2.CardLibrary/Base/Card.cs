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
    public class Card
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
        string GameID { get; set; }

        /// <summary>
        /// 卡牌持有者
        /// </summary>
        string UserCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 卡牌描述
        /// </summary>
        string Describe { get; }
        /// <summary>
        /// 稀有程度
        /// </summary>
        Rarity Rare { get; }

        CardLocation CardLocation { get; set; }
    }
}
