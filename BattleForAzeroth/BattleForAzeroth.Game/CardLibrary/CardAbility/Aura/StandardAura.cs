using System;
using System.Linq;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BUFF;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Parameter;
namespace BattleForAzeroth.Game.CardLibrary.CardAbility.Aura
{
    public class StandardAura<Buff> : IAura where Buff : IBuff<ICardLocationFilter, IEvent, IBuffRestore<ICardLocationFilter, IEvent>>
    {
        public Card AuraCard { get; set; }
        public ICardLocationFilter LocationFilter { get; set; }

        public StandardAura(Card auraCard) => AuraCard = auraCard;

        public IActionOutputParameter Action(ActionParameter actionParameter)
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

        public void RestoreAura(ActionParameter actionParameter)
        {
            Buff buff = (Buff)Activator.CreateInstance(typeof(Buff), AuraCard);
            
            foreach (Card card in actionParameter.GameContext.AllCard.Where(c => c.Buffs.Any(x => x.GetType() == buff.BuffRestore.GetType() && x.MasterCard.CardInGameCode == AuraCard.CardInGameCode)))
            {
                foreach (IBuffRestore<ICardLocationFilter, IEvent> restoreBuff in card.Buffs.Where(x => x.GetType() == buff.BuffRestore.GetType() && x.MasterCard.CardInGameCode == AuraCard.CardInGameCode))
                {
                    var para = new ActionParameter()
                    {
                        PrimaryCard = card,
                        GameContext = actionParameter.GameContext
                    };
                    restoreBuff.Action(para);
                }
            }
        }
    }
}
