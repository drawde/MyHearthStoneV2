using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class Whirlwind : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "旋风斩";
        public override int Cost { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;
        public override int BuffCost { get; set; } = 1;
        public override string Describe { get; set; } = "对所有随从造成1点伤害。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_Whirlwind() };

        public override string BackgroudImage { get; set; } = "W6_076_D.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
