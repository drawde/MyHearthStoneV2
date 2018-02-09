﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
{
    public class Eviscerate : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "刺骨";
        public override int Cost { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        public override string Describe { get; set; } = "造成2点伤害。连击：造成4点伤害取而代之。";

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new CA_Eviscerate() };

        public override string BackgroudImage { get; set; } = "Classical/Eviscerate.jpg";
        public override Profession Profession { get; set; } = Profession.Rogue;
    }
}
