using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Context;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Preparation : IBaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;

        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            foreach (var spell in user.HandCards.Where(c => c.CardType == CardType.法术))
            {
                spell.Cost -= 3;
                spell.Abilities.Add(new REV_Preparation());
            }
            return null;
        }
    }
}
