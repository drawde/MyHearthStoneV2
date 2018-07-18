
using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System;
using System.Linq;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 将一个目标标记为死亡
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    public class Death<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            foreach (var card in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                BaseBiology biology = card as BaseBiology;
                biology.IsDeathing = true;
                ActionParameter para = new ActionParameter
                {
                    PrimaryCard = biology,
                    GameContext = actionParameter.GameContext
                };
                CardActionFactory.CreateAction(biology, ActionType.死亡).Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
