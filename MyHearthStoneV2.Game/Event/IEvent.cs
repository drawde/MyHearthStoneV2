using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.Event
{
    /// <summary>
    /// 游戏事件接口（指由玩家的某种游戏操作引发的通知，这个通知在游戏环境对象中广播，由各个卡牌对象捕获、响应）
    /// </summary>
    public interface IEvent
    {
        BaseActionParameter Parameter { get; set; }
        Card EventCard { get; set; }

        void Settlement();
    }
}
