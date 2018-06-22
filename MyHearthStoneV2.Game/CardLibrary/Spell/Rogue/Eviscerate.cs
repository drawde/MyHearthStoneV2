using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Rogue
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
