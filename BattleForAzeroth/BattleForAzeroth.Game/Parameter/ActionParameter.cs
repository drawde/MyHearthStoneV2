using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.Equip;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.Parameter
{
    /// <summary>
    /// 行为参数（用于封装触发卡牌技能、卡牌动作、控制器等的参数）
    /// </summary>
    public class ActionParameter
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

        public int DamageOrHeal { get; set; }
        /// <summary>
        /// 主体卡牌将要进入的牌桌位置
        /// </summary>
        public int PrimaryCardIndex { get; set; }
        public int DeskIndex { get; set; }
        public bool IsActivation { get; set; }
        public BaseEquip Equip { get; set; }

        public BaseHero Hero { get; set; }
        public int DrawCount { get; set; }
        public int DropCount { get; set; }
        public PickType DropCardType { get; set; } = PickType.随机;

        /// <summary>
        /// 弃牌方式为指定时，设置为被弃牌的下标
        /// </summary>
        public List<int> DropCardIndex { get; set; } = new List<int>();
        public int ReturnCount { get; set; }

        /// <summary>
        /// 容器数字，用来在多个技能之间传递（小鬼爆破）
        /// </summary>
        public int? CNTR_Number { get; set; } = null;
    }
}
