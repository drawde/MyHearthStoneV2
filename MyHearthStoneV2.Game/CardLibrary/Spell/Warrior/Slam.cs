using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Assert.Survival;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.Filter.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class Slam : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "猛击";
        public override int Cost { get; set; } = 2;
        public override int InitialCost { get; set; } = 2;
        public override string Describe { get; set; } = "对一个随从造成2点伤害，如果它依然存活，则抽一张牌。";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new SpellDriver_Single_AllServant<
                DoubleAbility<
                    RiseDamage<SecondaryServantFilter,Two,ONE,PhysicalDamage>,
                    Assert<SecondaryCardSurvival,DrawCard<MainUserContextFilter,ONE>,Null>>>()
        };

        public override string BackgroudImage { get; set; } = "W6_002_D.png";
        public override Profession Profession { get; set; } = Profession.Warrior;

        public override int Damage { get; set; } = 2;
    }
}
