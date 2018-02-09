namespace MyHearthStoneV2.Game.CardLibrary.Spell
{
    /// <summary>
    /// 法术类卡牌
    /// </summary>
    public abstract class BaseSpell : Card
    {
        public override CardType CardType { get; set; } = CardType.法术;

        /// <summary>
        /// 法术伤害
        /// </summary>
        public virtual int Damage { get; set; } = 0;

        /// <summary>
        /// 治疗量
        /// </summary>
        //public virtual int Heal { get; set; } = 0;
    }
}
