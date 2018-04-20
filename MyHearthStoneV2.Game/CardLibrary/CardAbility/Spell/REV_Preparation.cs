using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using System.Linq;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class REV_Preparation : IBaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        //public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get; set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.己方回合结束 };

        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            foreach (var spell in user.HandCards.Where(c => c.CardType == CardType.法术 && c.Abilities.Any(x => x.GetType() == GetType())))
            {
                spell.Cost += 3;
                spell.Abilities.RemoveAt(spell.Abilities.FindIndex(c => c.GetType() == GetType()));
            }
            return null;
        }
    }
}
