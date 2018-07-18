using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Context
{
    /// <summary>
    /// 玩家操作或回合开始、结束引发的一系列游戏操作
    /// </summary>
    public class ActionStatement
    {
        public ActionParameter CardActionParameter { get; set; }

        public IGameAction GameAction { get; set; }

        public delegate IActionOutputParameter SettlementEventHandler(ActionParameter CardActionParameter);

        /// <summary>
        /// 结算这个操作
        /// </summary>
        public void Settlement()
        {
            SettlementEventHandler handler = new SettlementEventHandler(GameAction.Action);
            handler.Invoke(CardActionParameter);            
        }
    }
}
