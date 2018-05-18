using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Filter.Context;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.Widget.Number;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Condition.Assert.Survival;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class Slam : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "猛击";
        public override int Cost => 2;
        public override int InitialCost => 2;
        public override string Describe => "对一个随从造成2点伤害，如果它依然存活，则抽一张牌。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new SpellDriver_Single_AllServant<
                DoubleAbility<
                    RiseDamage<SecondaryServantFilter,Two,ONE,PhysicalDamage>,
                    Assert<SecondaryCardSurvival,DrawCard<PrimaryUserContextFilter,ONE>,Null>>>()
        };

        public override string BackgroudImage => "W6_002_D.png";
        public override Profession Profession => Profession.Warrior;

        public override int Damage => 2;
    }
}
