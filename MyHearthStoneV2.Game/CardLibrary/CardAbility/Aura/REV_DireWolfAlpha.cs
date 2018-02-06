using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Aura
{
    public class REV_DireWolfAlpha : BaseCardAbility
    {
        public override AbilityType AbilityType { get; set; } = AbilityType.光环BUFF;
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant servant = actionParameter.MainCard as BaseServant;
            servant.Damage -= 1;
            if (servant.Damage < 1)
            {
                servant.Damage = 0;
            }
            return null;
        }
    }
}
