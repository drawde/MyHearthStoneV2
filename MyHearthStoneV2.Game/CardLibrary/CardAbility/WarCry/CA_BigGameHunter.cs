using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry
{
    public class CA_BigGameHunter : BaseCardAbility
    {
        public override CastStyle CastStyle { get; set; } = CastStyle.随从;

        public override AbilityType AbilityType { get; set; } = AbilityType.战吼;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.SecondaryCard as BaseServant;
            if (servant.Damage >= 7)
            {
                servant.Deathing = true;
            }
            return null;
        }
    }
}
