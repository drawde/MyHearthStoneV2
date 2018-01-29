using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer
{
    public class CA_FrothingBerserker : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.触发;
        public override List<SpellCardAbilityTime> SpellCardAbilityTimes { get;  set; } = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.随从受伤 };
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.MainCard as BaseServant;
            servant.Damage += 1;
            servant.BuffDamage += 1;
            return null;
        }
    }
}
