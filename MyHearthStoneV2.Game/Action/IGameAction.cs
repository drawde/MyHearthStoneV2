using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Action
{
    /// <summary>
    /// 卡牌或技能、行为规范，用于阶段队列结算
    /// </summary>
    public interface IGameAction
    {
        IActionOutputParameter Action(BaseActionParameter actionParameter);
    }
}
