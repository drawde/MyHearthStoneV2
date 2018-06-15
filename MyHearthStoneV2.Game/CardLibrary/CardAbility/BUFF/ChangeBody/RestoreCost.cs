﻿using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Direction;
using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.Event;
using System;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.ChangeBody
{
    public class RestoreCost<TAG, NUM, QAT, D, F, EVENT> : IBuffRestore<ICardLocationFilter, IEvent>, ICapture<ICardLocationFilter, IEvent>
        where TAG : IParameterFilter
        where NUM : INumber
        where QAT : INumber
        where D : IDirection
        where EVENT : IEvent
        where F : ICardLocationFilter
    {
        public Card MasterCard { get; set; }
        public RestoreCost(Card masterCard) => MasterCard = masterCard;

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
                foreach (Card card in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
                {
                    card.Cost += direction.SetNumber(num);                    
                }
            }
            return null;
        }

        public bool TryCapture(Card card, IEvent @event)
        {
            F locationFilter = GameActivator<F>.CreateInstance();
            ICardLocationFilter filter = GameActivator<F>.CreateInstance();
            return filter.Filter(card) && @event.GetType() == locationFilter.GetType() && @event.Parameter.GameContext.IsThisActivationUserCard(card);
        }
    }
}
