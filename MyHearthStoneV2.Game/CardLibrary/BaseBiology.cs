namespace MyHearthStoneV2.Game.CardLibrary
{
    /// <summary>
    /// 生物牌（随从、英雄）
    /// </summary>
    public abstract class BaseBiology : Card
    {
        /// <summary>
        /// 初始生命值
        /// </summary>
        public virtual int InitialLife { get; set; }

        /// <summary>
        /// 初始伤害
        /// </summary>
        public virtual int InitialDamage { get; set; }


        /// <summary>
        /// 生命值
        /// </summary>
        public virtual int Life { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public virtual int Damage { get; set; }


        /// <summary>
        /// 被法术或技能修改后的生命值
        /// </summary>
        public virtual int BuffLife { get; set; }

        /// <summary>
        /// 当前回合剩余攻击次数
        /// </summary>
        public virtual int RemainAttackTimes { get; set; }

        /// <summary>
        /// 在牌桌上的位置
        /// </summary>
        public virtual int DeskIndex { get; set; } = -1;

        /// <summary>
        /// 能否攻击（和剩余攻击次数配合使用）
        /// </summary>
        public virtual bool CanAttack { get; set; } = true;

        /// <summary>
        /// 种族
        /// </summary>
        public virtual Race Race { get; set; } = Race.无;

        /// <summary>
        /// 是否被标记为已死亡（力量的代价效果）
        /// </summary>
        public virtual bool IsDeathing { get; set; } = false;

        #region 基础技能
        public virtual bool HasHolyShield { get; set; } = false;
        public virtual bool HasTaunt { get; set; } = false;
        public virtual bool HasCharge { get; set; } = false;
        public virtual bool HasWindfury { get; set; } = false;

        /// <summary>
        /// 剧毒
        /// </summary>
        public virtual bool HasPoison { get; set; } = false;

        /// <summary>
        /// 超级风怒
        /// </summary>
        public virtual bool HasMegaWindfury { get; set; } = false;
        /// <summary>
        /// 潜行
        /// </summary>
        public virtual bool HasStealth { get; set; } = false;

        /// <summary>
        /// 法术强度
        /// </summary>
        public virtual int SpellPower { get; set; } = 0;
        #endregion
    }
}
