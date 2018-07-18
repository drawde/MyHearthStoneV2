using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Action
{
    /// <summary>
    /// 卡牌或技能、行为规范，用于阶段队列结算
    /// </summary>
    public interface IGameAction
    {
        IActionOutputParameter Action(ActionParameter actionParameter);
    }
}
