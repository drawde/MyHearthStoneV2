using MyHearthStoneV2.Game.Parameter;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Silence<TAG> : IBaseCardAbility where TAG : IFilter
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            TAG tag = GameActivator<TAG>.CreateInstance();
            foreach (BaseBiology biology in actionParameter.GameContext.DeskCards.Where(tag.Filter(actionParameter)).OrderBy(c => c.CastIndex))
            {
                DisableCardAbility(biology, actionParameter.GameContext);
            }
            
            return null;
        }

        private void DisableCardAbility(BaseBiology bio, GameContext gameContext)
        {
            if (bio.Abilities.Any(c => c.AbilityType == AbilityType.BUFF))
            {
                foreach (var ability in bio.Abilities)
                {
                    CardAbilityParameter para = new CardAbilityParameter()
                    {
                        GameContext = gameContext,
                        MainCard = bio,
                    };
                    ability.Action(para);
                }
            }
            bio.Damage = bio.Damage < bio.InitialDamage ? bio.Damage : bio.InitialDamage;
            bio.Cost = bio.Cost < bio.InitialCost ? bio.Cost : bio.InitialCost;
            bio.Life = bio.Life < bio.InitialLife ? bio.Life : bio.InitialLife;

            bio.BuffLife = bio.InitialLife;

            bio.Abilities.Clear();
        }
    }
}
