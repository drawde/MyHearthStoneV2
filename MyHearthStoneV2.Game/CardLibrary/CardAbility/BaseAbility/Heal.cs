using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using System;
using MyHearthStoneV2.Game.Event;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Heal<TAG, C> : ICardAbility where TAG : IFilter where C : INumber
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            C qat = GameActivator<C>.CreateInstance();

            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                var para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext, qat.GetNumber(actionParameter), secondaryCard: actionParameter.MainCard);
                CardActionFactory.CreateAction(biology, ActionType.受到治疗).Action(para);
            }
            return null;
        }
        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
