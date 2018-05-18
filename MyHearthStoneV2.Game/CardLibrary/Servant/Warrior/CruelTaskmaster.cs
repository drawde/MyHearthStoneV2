﻿using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.BattlecryDriver;

namespace MyHearthStoneV2.Game.CardLibrary.Servant.Warrior
{
    public class CruelTaskmaster : BaseServant
    {
        public override int Damage => 2;
        public override int Life => 2;
        public override int Cost => 2;

        public override int InitialDamage => 2;
        public override int InitialLife => 2;
        public override int InitialCost => 2;

        
        public override int BuffLife => 2;

        public override string Describe
        {
            get
            {
                return "战吼：对一个随从造成1点伤害，并使其获得 2攻击力。";
            }
        }

        public override Rarity Rare
        {
            get
            {
                return Rarity.普通;
            }
        }

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new AllServantBattlecryDriver<
                DoubleActionDriver<
                    RiseDamage<SecondaryServantFilter,ONE,ONE,PhysicalDamage>,
                    AddDamage<SecondaryServantFilter,Two>,NullFilter>
                >(),
            //new CA_CruelTaskmaster()
        };


        public override string Name => "严酷的监工";
        public override string BackgroudImage => "W6_196_D.png";

        public override Profession Profession => Profession.Warrior;
    }
}
