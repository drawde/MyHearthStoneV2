using BattleForAzeroth.Game.CardLibrary.Equip;

namespace BattleForAzeroth.Game.CardLibrary.Hero
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

        public override int Life { get; set; } = 30;
        public override int InitialLife { get; set; } = 30;
        public override int BuffLife { get; set; } = 30;

        public override CardType CardType { get; set; } = CardType.英雄;

        /// <summary>
        /// 装备
        /// </summary>
        public virtual BaseEquip Equip { get; set; }

        /// <summary>
        /// 英雄技能的费用
        /// </summary>
        public int HeroPowerCost { get; set; } = 2;
    }
}
