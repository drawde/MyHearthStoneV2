using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter.Equip
{
    internal class EquipActionParameter: BaseActionParameter
    {
        internal BaseEquip Equip { get; set; }

        internal BaseHero Hero { get; set; }
    }
}
