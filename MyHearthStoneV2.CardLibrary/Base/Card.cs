using MyHearthStoneV2.CardLibrary.SpecialEffect;
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
    public interface Card
    {
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
