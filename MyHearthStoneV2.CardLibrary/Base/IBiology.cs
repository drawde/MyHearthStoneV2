using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.Base
{
    /// <summary>
    /// 生物牌（随从、英雄）
    /// </summary>
    public abstract class IBiology : Card
    {
        /// <summary>
        /// 生命值
        /// </summary>
        public int Life { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public int Damage { get; set; }
        /// <summary>
        /// 卡牌ID
        /// </summary>
        public string CardID { get; set; }

        public List<BuffTime> LstBuff { get; set; }

        /// <summary>
        /// 当前回合剩余攻击次数
        /// </summary>
        public int CurrentRoundRemainingAttackTimes { get; set; }
    }
}
