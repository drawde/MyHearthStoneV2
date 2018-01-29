
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Neutral.Classical
{
    public class LuckyCoin: BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "幸运币";
        public override int Cost { get; set; } = 0;

        public override int BuffCost { get; set; } = 0;
        public override string Describe { get; set; } = "";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new AppendPower() };

        public override string BackgroudImage { get; set; } = "coin_D_1.png";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
