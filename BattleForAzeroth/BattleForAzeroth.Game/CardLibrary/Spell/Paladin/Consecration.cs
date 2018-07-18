using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using BattleForAzeroth.Game.Widget.Number;
using System.Collections.Generic;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Paladin
{
    public class Consecration : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "奉献";
        public override int Cost { get; set; }  = 4;
        public override int InitialCost => 4;
        public override string Describe => "对所有敌人造成2点伤害。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver
            <
                RiseDamage<AllPrimaryEnemyFilter,Two,ONE,SpellDamage>
            >(),
        };

        public override string BackgroudImage => "Paladin/Consecration.jpg";
        public override Profession Profession => Profession.Paladin;
    }
}
