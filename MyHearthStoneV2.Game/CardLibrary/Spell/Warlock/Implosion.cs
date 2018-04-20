﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Spell;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warlock
{
    public class Implosion : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "小鬼爆破";
        public override int Cost { get; set; } = 4;
        public override int InitialCost { get; set; } = 4;
        public override string Describe { get; set; } = "对一个随从造成2-4点伤害，每造成1点伤害，召唤一个1/1的小鬼。";

        public override List<IBaseCardAbility> Abilities { get; set; } = new List<IBaseCardAbility>()
        {
            //new SpellDriver<RiseDamage<SecondaryServantTarget,RandomQuantity<Two,Four>,ONE,SpellDamage>>(),
            new CA_Implosion()
        };

        public override string BackgroudImage { get; set; } = "GVG/Implosion.jpg";
        public override Profession Profession { get; set; } = Profession.Warlock;

        public override int Damage { get; set; } = 4;
    }
}
