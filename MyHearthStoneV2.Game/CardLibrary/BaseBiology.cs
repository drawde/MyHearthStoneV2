using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.Context;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary
{
    /// <summary>
    /// 生物牌（随从、英雄）
    /// </summary>
    public abstract class BaseBiology : Card
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
        /// 当前回合剩余攻击次数
        /// </summary>
        public virtual int RemainAttackTimes { get; set; }

        /// <summary>
        /// 在牌桌上的位置
        /// </summary>
        public virtual int DeskIndex { get; set; } = -1;

        /// <summary>
        /// 被攻击
        /// </summary>
        public virtual void UnderAttack(GameContext gameContext, BaseBiology attackCard)
        {
        }
    }
}
