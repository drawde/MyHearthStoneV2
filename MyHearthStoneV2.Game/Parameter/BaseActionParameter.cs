using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter
{
    /// <summary>
    /// 行为参数（用于封装触发卡牌技能、卡牌动作、控制器等的参数）
    /// </summary>
    public abstract class BaseActionParameter
    {
        public GameContext GameContext { get; set; }

        /// <summary>
        /// 主体卡牌
        /// </summary>
        public Card PrimaryCard { get; set; }

        /// <summary>
        /// 次要卡牌
        /// </summary>
        public Card SecondaryCard { get; set; }

        /// <summary>
        /// 用于（范克里夫）
        /// </summary>
        public Card TertiaryCard { get; set; }

        public UserContext UserContext { get; set; }

        /// <summary>
        /// 容器数字，用来在多个技能之间传递（小鬼爆破）
        /// </summary>
        public int? CNTR_Number { get; set; } = null;
    }
}
