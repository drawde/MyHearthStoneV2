using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Event;
using System;
using System.Linq;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 冲锋
    /// </summary>
    public class Charge<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            foreach (var card in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                BaseBiology biology = card as BaseBiology;
                biology.HasCharge = true;
                BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
