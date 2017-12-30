namespace MyHearthStoneV2.Game.CardLibrary.Spell
{
    /// <summary>
    /// 法术类卡牌
    /// </summary>
    public abstract class BaseSpell : Card
    {
        public override CardType CardType { get; set; } = CardType.法术;
    }
}
