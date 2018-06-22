using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.Widget.Condition.DamageType;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Spell.Single;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class InnerRage : BaseSpell
    {
        public override Rarity Rare => Rarity.普通;

        public override string Name => "怒火中烧";
        public override int Cost { get; set; }  = 0;
        public override int InitialCost => 0;
        public override string Describe => "对一个随从造成1点伤害，该随从获得+2攻击力。";
        public override int Damage { get; set; }  = 1;
        public override List<ICardAbility> Abilities => new List<ICardAbility>()
        {
            new SpellDriver_Single_AllServant
                <
                    DoubleActionDriver
                    <
                        RiseDamage<SecondaryServantFilter,ONE,ONE,SpellDamage>,
                        AddDamage<SecondaryServantFilter,Two>,NullFilter
                    >>(),
            //new CA_InnerRage()
        };

        public override string BackgroudImage => "W17_A197_D.png";
        public override Profession Profession => Profession.Warrior;
    }
}
