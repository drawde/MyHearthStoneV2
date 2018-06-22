using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class Whirlwind : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "旋风斩";
        public override int Cost { get; set; }  = 1;
        public override int InitialCost => 1;
        public override string Describe => "对所有随从造成1点伤害。";

        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new NoneTargetSpellDriver<RiseDamage<AllServantFilter,ONE,ONE,SpellDamage>>(),
            //new CA_Whirlwind()
        };

        public override string BackgroudImage => "W6_076_D.png";
        public override Profession Profession => Profession.Warrior;

        public override int Damage { get; set; }  = 1;
    }
}
