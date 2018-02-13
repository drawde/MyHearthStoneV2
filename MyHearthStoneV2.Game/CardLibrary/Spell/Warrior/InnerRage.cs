using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Quantity;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using System.Collections.Generic;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class InnerRage : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "怒火中烧";
        public override int Cost { get; set; } = 0;
        public override int InitialCost { get; set; } = 0;
        public override string Describe { get; set; } = "对一个随从造成1点伤害，该随从获得+2攻击力。";
        public override int Damage { get; set; } = 1;
        public override List<BaseCardAbility> Abilities { get; set; } = new List<BaseCardAbility>()
        {
            new SpellDriver
                <
                    DoubleActionDriver
                    <
                        RiseDamage<SecondaryServantFilter,ONE,ONE,SpellDamage>,
                        AddDamage<SecondaryServantFilter,Two>
                    >
                >(),
            //new CA_InnerRage()
        };

        public override string BackgroudImage { get; set; } = "W17_A197_D.png";
        public override Profession Profession { get; set; } = Profession.Warrior;
    }
}
