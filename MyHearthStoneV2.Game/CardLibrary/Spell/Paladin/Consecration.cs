using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using MyHearthStoneV2.Game.Widget.Number;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Paladin
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
