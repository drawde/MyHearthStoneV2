using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class DeadlyPoison : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "致命药膏";
        public override int Cost { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;
        public override string Describe { get; set; } = "使你的武器获得+2攻击力。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new UpgradeWeapon() { AbilityType = AbilityType.法术 } };

        public override string BackgroudImage { get; set; } = "Classical/DeadlyPoison.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
