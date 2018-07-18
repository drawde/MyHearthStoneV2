using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Direction;
using BattleForAzeroth.Game.Capture;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using System;
using BattleForAzeroth.Game.Context;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF.ChangeBody
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

        public IActionOutputParameter Action(ActionParameter actionParameter)
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
