using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using System;
using MyHearthStoneV2.Game.Event;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Silence<TAG> : ICardAbility where TAG : IParameterFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
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
                    CardAbilityParameter para = new CardAbilityParameter()
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
