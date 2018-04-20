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
        public Card MainCard { get; set; }

        /// <summary>
        /// 次要卡牌
        /// </summary>
        public Card SecondaryCard { get; set; }

        public UserContext UserContext { get; set; }
    }
}
