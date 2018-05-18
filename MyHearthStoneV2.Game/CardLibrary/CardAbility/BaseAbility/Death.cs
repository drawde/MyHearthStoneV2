using MyHearthStoneV2.Common;
using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 将一个目标标记为死亡
    /// </summary>
    /// <typeparam name="TAG"></typeparam>
    public class Death<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            foreach (var card in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                BaseBiology biology = card as BaseBiology;
                biology.IsDeathing = true;
                BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                CardActionFactory.CreateAction(biology, ActionType.死亡).Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
