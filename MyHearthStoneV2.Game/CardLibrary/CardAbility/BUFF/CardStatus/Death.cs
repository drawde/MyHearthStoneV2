using MyHearthStoneV2.Game.Capture;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF.CardStatus
{
    public class Death<TAG, F, EVENT> : IBuffRestore<ICardLocationFilter, IEvent>, ICapture<ICardLocationFilter, IEvent> where TAG : IFilter where EVENT : IEvent where F : ICardLocationFilter
    {
        public Card MasterCard { get; set; }

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            foreach (Card card in actionParameter.GameContext.AllCard.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                BaseBiology baseBiology = card as BaseBiology;
                baseBiology.IsDeathing = true;
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
