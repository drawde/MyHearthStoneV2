using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Preparation : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "伺机待发";
        public override int Cost { get; set; } = 0;
        public override int InitialCost { get; set; } = 0;
        public override string Describe { get; set; } = "在本回合中，你所施放的下一个法术的法力值消耗减少（3）点。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_Preparation() };

        public override string BackgroudImage { get; set; } = "Classical/Preparation.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
