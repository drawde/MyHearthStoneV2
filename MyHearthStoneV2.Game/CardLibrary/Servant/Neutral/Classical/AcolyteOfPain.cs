﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Observer;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class AcolyteOfPain : BaseServant
    {
        public override int Damage { get; set; } = 1;
        public override int Life { get; set; } = 3;
        public override int Cost { get; set; } = 3;

        public override int InitialDamage { get; set; } = 1;
        public override int InitialLife { get; set; } = 3;
        public override int InitialCost { get; set; } = 3;

        
        public override int BuffLife { get; set; } = 3;
        public override string Describe { get; set; } = "每当该随从受到伤害时，抽一张牌。";

        public override Rarity Rare { get; set; } = Rarity.史诗;

        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>() { new DrawCard() { DrawCount = 1, SpellCardAbilityTimes = new List<SpellCardAbilityTime>() { SpellCardAbilityTime.受伤} } };


        public override string Name { get; set; } = "苦痛侍僧";
        public override string BackgroudImage { get; set; } = "W10_A031_D.png";

        public override Profession Profession { get; set; } = Profession.Neutral;
    }
}
