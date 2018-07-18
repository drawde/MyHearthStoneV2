using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Event
{
    /// <summary>
    /// 游戏事件接口（指由玩家的某种游戏操作引发的通知，这个通知在游戏环境对象中广播，由各个卡牌对象捕获、响应）
    /// </summary>
    public interface IEvent
    {
        ActionParameter Parameter { get; set; }
        Card EventCard { get; set; }

        void Settlement();
    }
}
