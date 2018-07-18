using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Context;
using System.Linq;

namespace BattleForAzeroth.Game.Event
{
    public abstract class RespondEvent
    {
        public virtual void Respond(IEvent @event)
        {
            GameContext gameContext = @event.Parameter.GameContext;
            foreach (Card card in gameContext.AllCard.Where(c => c.Abilities.Any(x => x.TryCapture(c, @event))))
            {
                //if (card.Abilities.Any(c => c.TryCapture(card, @event)))
                //{

                //}
                @event.Parameter.TertiaryCard = card;
                gameContext.AddActionStatements(card.Abilities.Where(c => c.TryCapture(card, @event)), @event.Parameter);//(c as BaseDriver<IGameAction, ICardLocationFilter>)
            }
        }
    }
}
