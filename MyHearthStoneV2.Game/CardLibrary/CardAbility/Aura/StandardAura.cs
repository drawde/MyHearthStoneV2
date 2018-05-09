using System;
using System.Linq;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BUFF;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.CardAbility;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura
{
    public class StandardAura<Buff> : IAura where Buff : IBuff<ICardLocationFilter, IEvent, IBuffRestore<ICardLocationFilter, IEvent>>
    {
        public Card AuraCard { get; set; }
        public ICardLocationFilter LocationFilter { get; set; }

        public StandardAura(Card auraCard) => AuraCard = auraCard;

        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            if (actionParameter.GameContext.Aurae.Contains(this) == false)
            {
                actionParameter.GameContext.Aurae.AddLast(this);
            }
            else if (LocationFilter.Filter(AuraCard) == false)
            {
                actionParameter.GameContext.Aurae.Remove(this);
            }

            if (LocationFilter.Filter(AuraCard))
            {
                return Activator.CreateInstance<Buff>().Action(actionParameter);
            }
            return null;
        }

        public bool TryCapture(Card card, IEvent @event) => false;

        public void RestoreAura(BaseActionParameter actionParameter)
        {
            Buff buff = (Buff)Activator.CreateInstance(typeof(Buff), AuraCard);
            
            foreach (Card card in actionParameter.GameContext.AllCard.Where(c => c.Buffs.Any(x => x.GetType() == buff.BuffRestore.GetType() && x.MasterCard.CardInGameCode == AuraCard.CardInGameCode)))
            {
                foreach (IBuffRestore<ICardLocationFilter, IEvent> restoreBuff in card.Buffs.Where(x => x.GetType() == buff.BuffRestore.GetType() && x.MasterCard.CardInGameCode == AuraCard.CardInGameCode))
                {
                    CardAbilityParameter para = new CardAbilityParameter()
                    {
                        MainCard = card,
                        GameContext = actionParameter.GameContext
                    };
                    restoreBuff.Action(para);
                }
            }
        }
    }
}
