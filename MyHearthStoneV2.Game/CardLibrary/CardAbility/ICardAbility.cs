using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility
{
    /// <summary>
    /// 卡牌技能基类
    /// </summary>
    public interface ICardAbility : IGameAction, ICapture<ICardLocationFilter, IEvent>
    {

    }
}
