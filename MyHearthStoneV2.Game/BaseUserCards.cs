using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game
{
    public abstract class BaseUserCards
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

        /// <summary>
        /// 开局时是否换了牌
        /// </summary>
        public bool SwitchDone { get; set; }
    }
}
