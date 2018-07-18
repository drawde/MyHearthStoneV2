using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Filter.Context;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using BattleForAzeroth.Game.Widget.Number;
using System.Collections.Generic;
using BattleForAzeroth.Game.Widget.Condition.Assert.Survival;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Warrior
{
    public class Slam : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "猛击";
        public override int Cost { get; set; }  = 2;
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

        public override int Damage { get; set; }  = 2;
    }
}
