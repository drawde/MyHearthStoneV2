﻿using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Direction;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using System;
using MyHearthStoneV2.Game.Action;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody
{
    public class RestoreDamage<TAG, NUM, QAT, D, F, EVENT> : IBuffRestore<ICardLocationFilter, IEvent>, ICapture<ICardLocationFilter, IEvent>
        where TAG : IFilter
        where NUM : INumber
        where QAT : INumber
        where D : IDirection
        where EVENT : IEvent
        where F : ICardLocationFilter
    {
        public Card MasterCard { get; set; }
        public RestoreDamage(Card masterCard) => MasterCard = masterCard;

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            NUM num = GameActivator<NUM>.CreateInstance();
            QAT qat = GameActivator<QAT>.CreateInstance();
            D direction = Activator.CreateInstance<D>();
            F locationFilter = GameActivator<F>.CreateInstance();
            //ET et = GameActivator<ET>.CreateInstance();

            for (int i = 0; i < qat.GetNumber(actionParameter); i++)
            {
                foreach (BaseBiology biology in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
                {
                    biology.Damage += direction.SetNumber(num);

                    //BaseActionParameter para = CardActionFactory.CreateParameter(biology, actionParameter.GameContext);
                    //CardActionFactory.CreateAction(biology, ActionType.重置攻击次数).Action(para);
                }
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
