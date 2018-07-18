
namespace BattleForAzeroth.Game.CardLibrary.Servant
{
    /// <summary>
    /// 随从基类
    /// </summary>
    public abstract class BaseServant : BaseBiology
    {
        public override CardType CardType { get; set; } = CardType.随从;
    }
}
