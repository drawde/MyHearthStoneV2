using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using System;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class AddDamage<TAG,Q> : ICardAbility where TAG : IFilter where Q : INumber
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(Activator.CreateInstance<TAG>().Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                biology.Damage += GameActivator<Q>.CreateInstance().GetNumber(actionParameter);
                BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
