using MyHearthStoneV2.Game.CardLibrary.Equip;

namespace MyHearthStoneV2.Game.CardLibrary.Hero
{
    /// <summary>
    /// 英雄牌基类
    /// </summary>
    public abstract class BaseHero: BaseBiology
    {
        /// <summary>
        /// 护甲值
        /// </summary>
        public virtual int Ammo { get; set; }

        public virtual Profession Profession { get; set; }

        public override int Life { get; set; } = 30;

        public override CardType CardType { get; set; } = CardType.英雄;

        /// <summary>
        /// 装备
        /// </summary>
        public virtual BaseEquip Equip { get; set; }
    }
}
