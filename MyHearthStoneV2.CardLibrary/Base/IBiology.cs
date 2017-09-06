﻿using MyHearthStoneV2.CardSpecialEffect;
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
        public virtual int Life { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public virtual int Damage { get; set; }
        /// <summary>
        /// 卡牌ID
        /// </summary>
        public virtual string CardID { get; set; }

        public virtual List<ISpecialEffect> LstBuff { get; set; }

        /// <summary>
        /// 当前回合剩余攻击次数
        /// </summary>
        public virtual int RemainAttackTimes { get; set; }
    }
}
