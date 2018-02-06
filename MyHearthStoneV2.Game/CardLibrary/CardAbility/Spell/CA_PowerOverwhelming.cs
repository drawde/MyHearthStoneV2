using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell
{
    public class CA_PowerOverwhelming : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.法术;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.SecondaryCard as BaseServant;
            servant.Life += 4;
            servant.BuffLife += 4;
            servant.Damage += 4;
            servant.Abilities.Add(new Death());
            return null;
        }
    }
}
