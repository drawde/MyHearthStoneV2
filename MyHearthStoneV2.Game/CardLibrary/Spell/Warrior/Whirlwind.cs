using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.DamageType;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant;
using System.Collections.Generic;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.Filter;

namespace MyHearthStoneV2.Game.CardLibrary.Spell.Warrior
{
    public class Whirlwind : BaseSpell
    {
        public override Rarity Rare { get; set; } = Rarity.普通;

        public override string Name { get; set; } = "旋风斩";
        public override int Cost { get; set; } = 1;
        public override int InitialCost { get; set; } = 1;
        public override string Describe { get; set; } = "对所有随从造成1点伤害。";

        public override List<ICardAbility> Abilities { get; set; } = new List<ICardAbility>()
        {
            new SpellDriver<RiseDamage<AllServantFilter,ONE,ONE,SpellDamage>,NullFilter>(),
            //new CA_Whirlwind()
        };

        public override string BackgroudImage { get; set; } = "W6_076_D.png";
        public override Profession Profession { get; set; } = Profession.Warrior;

        public override int Damage { get; set; } = 1;
    }
}
