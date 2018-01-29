using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Context
{
    /// <summary>
    /// 玩家操作或回合开始、结束引发的一系列游戏操作
    /// </summary>
    internal class ActionStatement
    {
        internal BaseActionParameter CardActionParameter { get; set; }

        internal IGameAction GameAction { get; set; }

        internal delegate IActionOutputParameter SettlementEventHandler(BaseActionParameter CardActionParameter);

        /// <summary>
        /// 结算这个操作
        /// </summary>
        internal void Settlement()
        {
            SettlementEventHandler handler = new SettlementEventHandler(GameAction.Action);
            handler.Invoke(CardActionParameter);            
        }
    }
}
