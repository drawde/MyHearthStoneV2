﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical
{
    public class IronbeakOwl : BaseServant
    {
        public override int Damage { get; set; } = 2;
        public override int Life { get; set; } = 1;
        public override int Cost { get; set; } = 1;

        public override int InitialDamage { get; set; } = 2;
        public override int InitialLife { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;
        
        public override int BuffLife { get; set; } = 1;

        public override string Describe { get; set; } = "战吼：沉默一个随从";

        public override Rarity Rare { get; set; } = Rarity.普通;

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new AllServantBattlecryDriver<Silence<MainServantFilter>,NullFilter>()
        };

        public override string BackgroudImage { get; set; } = "W4_280_D.png";

        public override string Name { get; set; } = "铁喙猫头鹰";
        public override Profession Profession { get; set; } = Profession.Neutral;
        public override Race Race { get; set; } = Race.野兽;
    }
}
