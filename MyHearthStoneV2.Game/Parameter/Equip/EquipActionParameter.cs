using MyHearthStoneV2.Game.CardLibrary.Equip;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Parameter.Equip
{
    public class EquipActionParameter: BaseActionParameter
    {
        public BaseEquip Equip { get; set; }

        public BaseHero Hero { get; set; }
    }
}
