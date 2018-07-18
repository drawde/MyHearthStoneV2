using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using BattleForAzeroth.Game.Widget.Condition.DamageType;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Collections.Generic;
using BattleForAzeroth.Game.CardLibrary.CardAbility.Driver;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.Spell.Rogue
{
    public class Eviscerate : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "刺骨";
        public override int Cost { get; set; }  = 2;
        public override int InitialCost => 2;
        public override string Describe => "造成2点伤害。连击：造成4点伤害取而代之。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new SpellDriver_Single_AllEnemy<
                ComboDriver<
                    RiseDamage<SecondaryFilter,Two,ONE,SpellDamage>,
                    RiseDamage<SecondaryFilter,Four,ONE,SpellDamage>,
                NullFilter>>(),
        };

        public override string BackgroudImage => "Classical/Eviscerate.jpg";
        public override Profession Profession => Profession.Rogue;
    }
}
