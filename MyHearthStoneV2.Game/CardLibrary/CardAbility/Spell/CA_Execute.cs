using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_Execute : IBaseCardAbility
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.敌方随从;

        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.SecondaryCard as BaseServant;
            if (servant.Life < servant.BuffLife)
            {
                servant.Deathing = true;
            }
            return null;
        }
    }
}
