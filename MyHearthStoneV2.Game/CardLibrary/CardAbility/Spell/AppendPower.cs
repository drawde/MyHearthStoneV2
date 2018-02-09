using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class AppendPower : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard).Power += 1;
            return null;
        }
    }
}
