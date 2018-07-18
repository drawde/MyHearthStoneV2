using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility
{
    /// <summary>
    /// 卡牌技能基类
    /// </summary>
    public interface ICardAbility : IGameAction, ICapture<ICardLocationFilter, IEvent>
    {

    }
}
