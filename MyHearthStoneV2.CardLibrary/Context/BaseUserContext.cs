using MyHearthStoneV2.CardLibrary.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Context
{
    public abstract class BaseUserContext
    {
        /// <summary>
        /// 选择的英雄
        /// </summary>
        public BaseHero hero { get; set; }

        public string UserCode { get; set; }
        /// <summary>
        /// 当前回合的费用
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// 是否先手
        /// </summary>
        public bool IsFirst { get; set; }

        /// <summary>
        /// 是否是这名玩家的回合
        /// </summary>
        public bool IsActivation { get; set; }

        /// <summary>
        /// 开局时是否换了牌
        /// </summary>
        public bool SwitchDone { get; set; }

        /// <summary>
        /// 进行完的回合数
        /// </summary>
        public int TurnIndex { get; set; }
    }
}
