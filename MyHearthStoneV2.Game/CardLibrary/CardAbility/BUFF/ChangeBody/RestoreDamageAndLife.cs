using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;
using System;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody
{
    public class RestoreDamageAndLife<TAG, DMG_NUM, LFE_NUM, D, F, EVENT> : IBuffRestore<ICardLocationFilter, IEvent>, ICapture<ICardLocationFilter, IEvent>
        where TAG : IParameterFilter
        where DMG_NUM : INumber
        where LFE_NUM : INumber
        where D : IDirection
        where EVENT : IEvent
        where F : ICardLocationFilter
    {
        public Card MasterCard { get; set; }
        public RestoreDamageAndLife(Card masterCard) => MasterCard = masterCard;

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            DMG_NUM num = GameActivator<DMG_NUM>.CreateInstance();
            LFE_NUM qat = GameActivator<LFE_NUM>.CreateInstance();
            D direction = Activator.CreateInstance<D>();
            F locationFilter = GameActivator<F>.CreateInstance();
            //ET et = GameActivator<ET>.CreateInstance();

            foreach (BaseBiology biology in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).Where(c => locationFilter.Filter(c)).OrderBy(c => c.CastIndex))
            {
                biology.BuffLife += direction.SetNumber(qat);
                biology.Life += direction.SetNumber(qat);
                biology.Damage += direction.SetNumber(num);

                //BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                //CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
            }
            return null;
        }

        public bool TryCapture(Card card, IEvent @event)
        {
            F locationFilter = GameActivator<F>.CreateInstance();
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == locationFilter.GetType() && @event.Parameter.UserContext.IsActivation;
        }
    }
}
