using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class ShieldBlock : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "盾牌格挡";
        public override int Cost { get; set; } = 3;
        public override int InitialCost { get; set; } = 3;
        public override string Describe { get; set; } = "获得5点护甲。抽1张牌。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_ShieldBlock() };

        public override string BackgroudImage { get; set; } = "WOW_MISC_021_D_1.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
