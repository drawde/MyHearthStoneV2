using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry
{
    public class CA_Loatheb : IBaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.战吼;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UserContext enemy = actionParameter.GameContext.GetEnemyUserContextByMyCard(actionParameter.MainCard);
            if (enemy.HandCards.Any(c => c.CardType == CardType.法术))
            {
                foreach (var spell in enemy.HandCards.Where(c => c.CardType == CardType.法术))
                {
                    spell.Cost += 5;
                    spell.Abilities.Add(new REV_Loatheb());
                }
            }
            return null;
        }
    }
}
