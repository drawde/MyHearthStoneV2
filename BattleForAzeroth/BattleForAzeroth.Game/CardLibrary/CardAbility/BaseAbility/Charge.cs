using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Action;
using BattleForAzeroth.Game.Event;
using System;
using System.Linq;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 冲锋
    /// </summary>
    public class Charge<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            foreach (var card in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                BaseBiology biology = card as BaseBiology;
                biology.HasCharge = true;
                ActionParameter para = new ActionParameter
                {
                    PrimaryCard = biology,
                    GameContext = actionParameter.GameContext
                };
                CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
