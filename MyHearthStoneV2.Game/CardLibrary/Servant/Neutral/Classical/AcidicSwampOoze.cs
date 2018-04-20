﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class AcidicSwampOoze : BaseServant
    {
        public override int Damage { get; set; } = 3;
        public override int Life { get; set; } = 2;
        public override int Cost { get; set; } = 2;

        public override int InitialDamage { get; set; } = 3;
        public override int InitialLife { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;


        public override int BuffLife { get; set; } = 2;
        public override string Describe { get; set; } = "战吼：摧毁你的对手的武器。";

        public override Rarity Rare { get; set; } = Rarity.精良;

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>()
        {
            new BattlecryDriver<DestroyEquip<SecondaryHeroFilter>,NullFilter>()
        };


        public override string Name { get; set; } = "酸性沼泽软泥怪";

        public override string BackgroudImage { get; set; } = "Classical/AcidicSwampOoze.jpg";

        public override Profession Profession { get; set; } = Profession.Neutral;

    }
}
