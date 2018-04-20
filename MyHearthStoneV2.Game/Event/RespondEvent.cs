using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Event
{
    public abstract class RespondEvent
    {
        public virtual void Respond(IEvent @event)
        {
            GameContext gameContext = @event.Parameter.GameContext;
            foreach (Card card in gameContext.AllCard)
            {
                //if (card.Abilities.Any(c => c.TryCapture(@event.EventCard, @event)))
                //{
                    
                //}
                gameContext.AddActionStatements(card.Abilities.Where(c => c.TryCapture(@event.EventCard, @event)), @event.Parameter);
            }
        }
    }
}
