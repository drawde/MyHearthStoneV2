using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    internal class Null : BaseCardAbility
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            return null;
        }
    }
}
