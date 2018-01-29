using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.WarCry.AlterBody
{
    public class REV_CruelTaskmaster : BaseCardAbility
    {
        public override IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            BaseServant card = actionParameter.MainCard as BaseServant;
            card.Damage -= 2;
            card.BuffDamage -= 2;
            //card.Buffs.Remove(card.Buffs.First(c => c.Value is CA_JiaoXiaoDeZhongShi).Key);
            card.Abilities.Remove(this);
            return null;
        }
    }
}
