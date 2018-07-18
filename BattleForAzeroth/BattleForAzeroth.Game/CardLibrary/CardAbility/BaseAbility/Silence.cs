using BattleForAzeroth.Game.Parameter;
using System.Linq;
using BattleForAzeroth.Game.Context;
using System;
using BattleForAzeroth.Game.Event;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Silence<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            TAG tag = Activator.CreateInstance<TAG>();
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                DisableCardAbility(biology, actionParameter.GameContext);
            }
            
            return null;
        }

        private void DisableCardAbility(BaseBiology bio, GameContext gameContext)
        {
            bio.Abilities.Clear();
            if (bio.Buffs.Any())
            {
                foreach (var ability in bio.Buffs)
                {
                    var para = new ActionParameter()
                    {
                        GameContext = gameContext,
                        PrimaryCard = bio,
                    };
                    ability.Action(para);
                }
            }
            bio.Damage = bio.Damage < bio.InitialDamage ? bio.Damage : bio.InitialDamage;
            bio.Cost = bio.Cost < bio.InitialCost ? bio.Cost : bio.InitialCost;
            bio.Life = bio.Life < bio.InitialLife ? bio.Life : bio.InitialLife;
            bio.BuffLife = bio.InitialLife;

            bio.Buffs.Clear();
        }

        public bool TryCapture(Card card, IEvent @event) => false;
    }
}
